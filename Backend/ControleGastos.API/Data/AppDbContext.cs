using ControleGastos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Pessoa> Pessoas => Set<Pessoa>();

        public DbSet<Transacao> Transacoes => Set<Transacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura o relacionamento entre Pessoa e Transação.
            // Uma pessoa pode possuir várias transações e cada transação pertence
            // a uma única pessoa.
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Transacoes)
                .WithOne(t => t.Pessoa)
                .HasForeignKey(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);


            // Configura o armazenamento do enum TipoTransacao como texto no banco.
            // Exemplo: "Receita" ou "Despesa".
            modelBuilder.Entity<Transacao>()
                .Property(t => t.Tipo)
                .HasConversion<string>();


            // Define a precisão dos valores.
            // Permite armazenar valores com até 18 dígitos e 2 casas decimais.
            modelBuilder.Entity<Transacao>()
                .Property(t => t.Valor)
                .HasPrecision(18, 2);
        }
    }
}