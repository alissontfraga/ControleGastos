using System.ComponentModel.DataAnnotations;

namespace ControleGastos.API.Models
{
    public class Pessoa
    {
      public Guid Id { get; set; }

      [Required]
      [MaxLength(80)]
      public string Nome { get; set; } = string.Empty;

      [Required]
      [Range(0,110)]
      public int Idade { get; set; }

      public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
      
    }
}