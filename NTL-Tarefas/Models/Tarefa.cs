using NTL_Tarefas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTL_Tarefas.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Titulo { get; set; }

        [MaxLength(500)]
        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Pendente;
    }
}
