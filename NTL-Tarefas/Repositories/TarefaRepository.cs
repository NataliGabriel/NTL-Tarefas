using Microsoft.EntityFrameworkCore;
using NTL_Tarefas.Data;
using NTL_Tarefas.Models;
using NTL_Tarefas.Repositories.Interfaces;

namespace NTL_Tarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context) => _context = context;

        public async Task<List<Tarefa>> ObterTodasAsync()
        {
            return await _context.Tarefas.AsNoTracking().ToListAsync();
        }
        public async Task<Tarefa?> ObterPorIdAsync(int id)
        {
            return await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Tarefa> CriarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }
        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }
        public async Task DeletarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
