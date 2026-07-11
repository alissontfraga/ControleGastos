using System.ComponentModel.DataAnnotations;

namespace ControleGastos.API.Models
{
    public class Pessoa
    {
      //gera um Id Global aleatóro
      public Guid Id { get; set; } = Guid.NewGuid();

      [Required]
      [MaxLength(80)]
      public string Nome { get; set; } = string.Empty;

      [Required]
      [Range(0,110)]
      public int Idade { get; set; }
  
      public ICollection<Transacao> Transacoes { get; set; } = [];
      
    }
}