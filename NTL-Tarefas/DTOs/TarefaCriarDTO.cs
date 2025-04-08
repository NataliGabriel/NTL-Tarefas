using System.ComponentModel.DataAnnotations;

namespace NTL_Tarefas.DTOs
{
    public class TarefaCriarDTO
    {
        [Required, MaxLength(100)]
        public string Titulo { get; set; }
        [MaxLength(500)]
        public string? Descricao { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
    }
}
