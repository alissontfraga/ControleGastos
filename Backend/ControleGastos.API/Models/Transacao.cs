using System.ComponentModel.DataAnnotations;
using ControleGastos.API.Enums;

namespace ControleGastos.API.Models
{
    public class Transacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(250)]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        public TipoTransacao Tipo { get; set; }

        public Guid PessoaId { get; set; }

        public Pessoa Pessoa { get; set; } = null!;
    }
}