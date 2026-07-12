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
        // Método responsável por criar uma nova pessoa.
        public async Task<PessoaResponse> CriarAsync(PessoaRequest request)
        {
            // Cria uma nova pessoa utilizando os dados recebidos da requisição.
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


        // Método responsável por buscar todas as pessoas cadastradas.
        public async Task<IEnumerable<PessoaResponse>> BuscarTodasAsync()
        {
            // Realiza a consulta das pessoas cadastradas sem alterar os dados.
            var pessoas = await context.Pessoas
                .AsNoTracking()
                .ToListAsync();

            return pessoas.Select(p => new PessoaResponse(
                p.Id,
                p.Nome,
                p.Idade
            ));
        }


        // Método responsável por buscar uma pessoa pelo ID.
        // Caso não exista, retorna uma exceção de recurso não encontrado.
        public async Task<PessoaResponse> BuscarPorIdAsync(Guid id)
        {
            var pessoa = await context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new NotFoundException("Pessoa não encontrada.");

            return new PessoaResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Idade
            );
        }


        // Método responsável por excluir uma pessoa pelo ID.
        // A exclusão também remove automaticamente suas transações relacionadas
        // devido à configuração de exclusão em cascata no Entity Framework.
        public async Task RemoverAsync(Guid id)
        {
            var pessoa = await context.Pessoas
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new NotFoundException("Pessoa não encontrada.");

            context.Pessoas.Remove(pessoa);

            await context.SaveChangesAsync();
        }
    }
}