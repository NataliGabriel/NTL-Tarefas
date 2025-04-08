using NTL_Tarefas.Models.Enums;

namespace NTL_Tarefas.DTOs
{
    public class TarefaAtualizarDTO
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public StatusEnum? Status { get; set; }
    }
}
