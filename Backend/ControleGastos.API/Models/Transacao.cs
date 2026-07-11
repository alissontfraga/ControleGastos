using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleGastos.API.Enums;

namespace ControleGastos.API.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public TipoTransacao Tipo { get; set; }

        public Guid PessoaId { get; set; }

        public Pessoa Pessoa { get; set; } = null!;
    }
}