using Microsoft.AspNetCore.Mvc;
using NTL_Tarefas.DTOs;
using NTL_Tarefas.Services.Interface;

namespace NTL_Tarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefasController(ITarefaService service) => _service = service;
 
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] TarefaCriarDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (dto.DataVencimento < DateTime.Now) return BadRequest("Data de Vencimento Inválida");

            var tarefa = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodas() => Ok(await _service.ObterTodasAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var tarefa = await _service.ObterPorIdAsync(id);
            return tarefa == null ? NotFound("Tarefa Não Encontrada") : Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] TarefaAtualizarDTO dto)
        {
            if (dto == null || NenhumCampoPreenchido(dto))
                return BadRequest("Pelo menos um campo deve ser informado para atualização.");

            var tarefa = await _service.AtualizarAsync(id, dto);
            return tarefa == null ? NotFound("Tarefa Não Encontrada Para Atualizar") : Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var sucesso = await _service.DeletarAsync(id);
            return sucesso ? NoContent() : NotFound("Tarefa Não Encontrada Para Deletar");
        }

        private bool NenhumCampoPreenchido(TarefaAtualizarDTO dto) =>
    dto.Titulo == null && dto.Descricao == null && dto.DataVencimento == null && dto.Status == null;

    }
}
