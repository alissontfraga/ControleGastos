using ControleGastos.API.Data;
using ControleGastos.API.DTOs.Transacoes;
using ControleGastos.API.Enums;
using ControleGastos.API.Exceptions;
using ControleGastos.API.Models;
using ControleGastos.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services
{
    public class TransacaoService(AppDbContext context) : ITransacaoService
    {

        // Método responsável por criar uma nova transação
        public async Task<TransacaoResponse> CriarAsync(TransacaoRequest request)
        {
            var pessoa = await context.Pessoas
                .FirstOrDefaultAsync(p => p.Id == request.PessoaId)
                ?? throw new NotFoundException("Pessoa não encontrada.");

            if (pessoa.Idade < 18 && request.Tipo == TipoTransacao.Receita)
            {
                throw new BusinessException(
                "Pessoas menores de idade podem cadastrar apenas despesas.");
            }

            var transacao = new Transacao
            {
                Id = Guid.NewGuid(),
                Descricao = request.Descricao,
                Valor = request.Valor,
                Tipo = request.Tipo,
                PessoaId = request.PessoaId
            };

            await context.Transacoes.AddAsync(transacao);

            await context.SaveChangesAsync();

            return new TransacaoResponse(
                transacao.Id,
                transacao.Descricao,
                transacao.Valor,
                transacao.Tipo,
                transacao.PessoaId
            );
        }

        // Método responsável por buscar todas as transações
        public async Task<IEnumerable<TransacaoResponse>> BuscarTodasAsync()
        {
            var transacoes = await context.Transacoes
                .ToListAsync();

            return transacoes.Select(t => new TransacaoResponse(
                t.Id,
                t.Descricao,
                t.Valor,
                t.Tipo,
                t.PessoaId
            ));
        }

        // Método responsável por buscar uma transação por ID
        public async Task<TransacaoResponse> BuscarPorIdAsync(Guid id)
        {
            var transacao = await context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new NotFoundException("Transação não encontrada.");

            return new TransacaoResponse(
                transacao.Id,
                transacao.Descricao,
                transacao.Valor,
                transacao.Tipo,
                transacao.PessoaId
            );
        }

        // Método responsável por remover uma transação por ID
        public async Task RemoverAsync(Guid id)
        {
            var transacao = await context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new NotFoundException("Transação não encontrada.");

            context.Transacoes.Remove(transacao);

            await context.SaveChangesAsync();
        }
    }
}