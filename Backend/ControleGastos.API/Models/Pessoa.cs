namespace ControleGastos.API.Models
{
    public class Pessoa
    {
        // Gera um identificador único automaticamente para cada pessoa cadastrada.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Nome da pessoa cadastrada.
        public string Nome { get; set; } = string.Empty;

        // Idade da pessoa, utilizada nas regras de negócio do sistema.
        public int Idade { get; set; }

        // Lista de transações associadas à pessoa.
        // A exclusão das transações ocorre automaticamente através
        // da configuração de Cascade Delete no Entity Framework.
        public ICollection<Transacao> Transacoes { get; set; } = [];
    }
}