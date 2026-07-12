using ControleGastos.API.Enums;

namespace ControleGastos.API.Models
{
    public class Transacao
    {
        // Gera um identificador único automaticamente para cada transação cadastrada.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Descrição informada para identificar a finalidade da transação.
        public string Descricao { get; set; } = string.Empty;

        // Valor da transação.
        public decimal Valor { get; set; }

        // Define se a transação representa uma receita ou uma despesa.
        public TipoTransacao Tipo { get; set; }

        // ID da pessoa vinculada à transação.
        public Guid PessoaId { get; set; }

        // Referência para a pessoa responsável pela transação.
        public Pessoa Pessoa { get; set; } = null!;
    }
}