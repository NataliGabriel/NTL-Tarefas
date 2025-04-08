using AutoMapper;
using NTL_Tarefas.DTOs;
using NTL_Tarefas.Models;
using NTL_Tarefas.Repositories.Interfaces;
using NTL_Tarefas.Services.Interface;

namespace NTL_Tarefas.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repo;
        private readonly IMapper _mapper;

        public TarefaService(ITarefaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TarefaResponseDTO>> ObterTodasAsync()
            => _mapper.Map<List<TarefaResponseDTO>>(await _repo.ObterTodasAsync());

        public async Task<TarefaResponseDTO?> ObterPorIdAsync(int id)
        {
            var tarefa = await _repo.ObterPorIdAsync(id);
            return tarefa == null ? null : _mapper.Map<TarefaResponseDTO>(tarefa);
        }

        public async Task<TarefaResponseDTO> CriarAsync(TarefaCriarDTO dto)
        {
            var tarefa = _mapper.Map<Tarefa>(dto);
            await _repo.CriarAsync(tarefa);
            return _mapper.Map<TarefaResponseDTO>(tarefa);
        }

        public async Task<TarefaResponseDTO?> AtualizarAsync(int id, TarefaAtualizarDTO dto)
        {
            var tarefa = await _repo.ObterPorIdAsync(id);
            if (tarefa == null) return null;

            if (dto.Titulo != null) tarefa.Titulo = dto.Titulo;
            if (dto.Descricao != null) tarefa.Descricao = dto.Descricao;
            if (dto.DataVencimento.HasValue) tarefa.DataVencimento = dto.DataVencimento.Value;
            if (dto.Status.HasValue) tarefa.Status = dto.Status.Value;

            await _repo.AtualizarAsync(tarefa);
            return _mapper.Map<TarefaResponseDTO>(tarefa);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var tarefa = await _repo.ObterPorIdAsync(id);
            if (tarefa == null) return false;

            await _repo.DeletarAsync(tarefa);
            return true;
        }
    }
}
