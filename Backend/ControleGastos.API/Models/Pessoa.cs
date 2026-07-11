namespace ControleGastos.API.Models
{
    public class Pessoa
    {
        // Gera um identificador único automaticamente
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; } = string.Empty;

        public int Idade { get; set; }

        public ICollection<Transacao> Transacoes { get; set; } = [];
    }
}