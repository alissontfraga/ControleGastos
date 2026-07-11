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

            // Entidade Pessoa
            modelBuilder.Entity<Pessoa>()
            .HasMany(p => p.Transacoes)
            .WithOne(t => t.Pessoa)
            .HasForeignKey(t => t.PessoaId)
            .OnDelete(DeleteBehavior.Cascade);

            // Entidade Transação
            modelBuilder.Entity<Transacao>()
            .Property(t => t.Tipo)
            .HasConversion<string>();

            modelBuilder.Entity<Transacao>()
            .Property(t => t.Valor)
            .HasPrecision(18,2);
        }
    }
}