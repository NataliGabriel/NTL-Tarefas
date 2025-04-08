using NTL_Tarefas.Models.Enums;

namespace NTL_Tarefas.DTOs
{
    public class TarefaResponseDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusEnum Status { get; set; }
    }
}
