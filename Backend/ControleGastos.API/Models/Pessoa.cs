using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleGastos.API.Models
{
    public class Pessoa
    {
      public Guid Id { get; set; }

      [Required]
      public string Nome { get; set; } = string.Empty;

      [Required]
      public int Idade { get; set; }

      public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
      
    }
}