using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NTL_Tarefas.Controllers;
using NTL_Tarefas.DTOs;
using NTL_Tarefas.Models.Enums;
using NTL_Tarefas.Services.Interface;

namespace NTL_Tarefas.Tests
{
    public class TarefasControllerTests
    {
        private readonly Mock<ITarefaService> _serviceMock;
        private readonly TarefasController _controller;

        public TarefasControllerTests()
        {
            _serviceMock = new Mock<ITarefaService>();
            _controller = new TarefasController(_serviceMock.Object);
        }

        [Fact]
        public async void POST_Criar_DeveRetornarCreated_QuandoValido()
        { 
            var dto = new TarefaCriarDTO
            {
                Titulo = "Entrega Quarta",
                Descricao = "Teste C#",
                DataVencimento = DateTime.Today.AddDays(3) 
            };

            var tarefaCriada = new TarefaResponseDTO
            {
                Id = 1,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataVencimento = dto.DataVencimento,
                Status = StatusEnum.Pendente
            };

            _serviceMock.Setup(s => s.CriarAsync(dto)).ReturnsAsync(tarefaCriada);
             
            var resultado = await _controller.Criar(dto);
             
            var createdResult = resultado as CreatedAtActionResult;
            createdResult.Should().NotBeNull();
            createdResult!.Value.Should().BeEquivalentTo(tarefaCriada);
            createdResult.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task POST_Criar_DeveRetornarBadRequest_QuandoInvalido()
        { 
            var dto = new TarefaCriarDTO();  
            _controller.ModelState.AddModelError("Titulo", "Obrigatório");
             
            var resultado = await _controller.Criar(dto);
             
            resultado.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task GET_ObterPorId_DeveRetornarOk_QuandoTarefaExiste()
        { 
            var id = 10;
            var tarefa = new TarefaResponseDTO
            {
                Id = id,
                Titulo = "Tarefa Existente",
                DataVencimento = DateTime.Today,
                Status = StatusEnum.EmAndamento
            };

            _serviceMock.Setup(s => s.ObterPorIdAsync(id)).ReturnsAsync(tarefa);
             
            var resultado = await _controller.ObterPorId(id);
             
            var okResult = resultado as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(tarefa);
        }

        [Fact]
        public async Task GET_ObterPorId_DeveRetornarNotFound_QuandoNaoExiste()
        { 
            var id = 999;
            _serviceMock.Setup(s => s.ObterPorIdAsync(id)).ReturnsAsync((TarefaResponseDTO?)null);
             
            var resultado = await _controller.ObterPorId(id);
             
            resultado.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public async Task PUT_Atualizar_DeveRetornarOk_QuandoTarefaExiste()
        { 
            var id = 1;
            var dto = new TarefaAtualizarDTO
            {
                Titulo = "Atualizado",
                Status = StatusEnum.Concluida
            };

            var tarefaAtualizada = new TarefaResponseDTO
            {
                Id = id,
                Titulo = dto.Titulo!,
                DataVencimento = DateTime.Today.AddDays(5),
                Status = dto.Status!.Value
            };

            _serviceMock.Setup(s => s.AtualizarAsync(id, dto)).ReturnsAsync(tarefaAtualizada);
             
            var resultado = await _controller.Atualizar(id, dto);
             
            var okResult = resultado as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(tarefaAtualizada);
        }

        [Fact]
        public async Task PUT_Atualizar_DeveRetornarNotFound_QuandoTarefaNaoExiste()
        { 
            var id = 999;
            var dto = new TarefaAtualizarDTO { Titulo = "Teste" };

            _serviceMock.Setup(s => s.AtualizarAsync(id, dto)).ReturnsAsync((TarefaResponseDTO?)null);
             
            var resultado = await _controller.Atualizar(id, dto);
             
            resultado.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DELETE_Deletar_DeveRetornarNoContent_QuandoSucesso()
        { 
            var id = 1;
            _serviceMock.Setup(s => s.DeletarAsync(id)).ReturnsAsync(true);
             
            var resultado = await _controller.Deletar(id);
             
            resultado.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DELETE_Deletar_DeveRetornarNotFound_QuandoTarefaNaoExiste()
        {
            
            var id = 999;
            _serviceMock.Setup(s => s.DeletarAsync(id)).ReturnsAsync(false);
             
            var resultado = await _controller.Deletar(id);
             
            resultado.Should().BeOfType<NotFoundResult>();
        }
    }
}