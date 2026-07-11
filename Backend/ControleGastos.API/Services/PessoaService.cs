using ControleGastos.API.Data;
using ControleGastos.API.DTOs.Pessoas;
using ControleGastos.API.Exceptions;
using ControleGastos.API.Models;
using ControleGastos.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services
{
    public class PessoaService(AppDbContext context) : IPessoaService
    {
        // Método responsável por criar uma nova pessoa
        public async Task<PessoaResponse> CriarAsync(PessoaRequest request)
        {
            var pessoa = new Pessoa
            {
                Nome = request.Nome,
                Idade = request.Idade
            };

            await context.Pessoas.AddAsync(pessoa);

            await context.SaveChangesAsync();

            return new PessoaResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Idade
            );
        }

        // Método responsável por buscar todas as pessoas cadastradas
        public async Task<IEnumerable<PessoaResponse>> BuscarTodasAsync()
        {
            var pessoas = await context.Pessoas
            .ToListAsync();

            return pessoas.Select(p => new PessoaResponse(
                p.Id,
                p.Nome,
                p.Idade
            ));
        }

        // Método responsável por buscar uma pessoa pelo ID
        public async Task<PessoaResponse?> BuscarPorIdAsync(Guid id)
        {
            var pessoa = await context.Pessoas
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new NotFoundException("Pessoa não encontrada");

            return new PessoaResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Idade
            );
        }

        // Método responsável por excluir uma pessoa pelo ID
        public async Task<bool> RemoverAsync(Guid id)
        {
            var pessoa = await context.Pessoas
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new NotFoundException("Pessoa não encontrada.");
                
            context.Pessoas.Remove(pessoa);

            await context.SaveChangesAsync();

            return true;
        }
    }
}