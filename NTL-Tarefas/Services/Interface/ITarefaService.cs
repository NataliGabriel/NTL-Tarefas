using NTL_Tarefas.DTOs;

namespace NTL_Tarefas.Services.Interface
{
    public interface ITarefaService
    {
        Task<List<TarefaResponseDTO>> ObterTodasAsync();
        Task<TarefaResponseDTO?> ObterPorIdAsync(int id);
        Task<TarefaResponseDTO> CriarAsync(TarefaCriarDTO dto);
        Task<TarefaResponseDTO?> AtualizarAsync(int id, TarefaAtualizarDTO dto);
        Task<bool> DeletarAsync(int id);
    }
}
