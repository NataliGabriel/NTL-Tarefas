using NTL_Tarefas.Models;

namespace NTL_Tarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> ObterTodasAsync();
        Task<Tarefa?> ObterPorIdAsync(int id);
        Task<Tarefa> CriarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task DeletarAsync(Tarefa tarefa);
    }
}
