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

        // Método responsável por criar uma nova transação.
        public async Task<TransacaoResponse> CriarAsync(TransacaoRequest request)
        {
            // Valida se o ID da pessoa foi informado.
            if (request.PessoaId == Guid.Empty)
            {
                throw new BusinessException("O identificador da pessoa é obrigatório.");
            }

            // Valida se o Valor é maior que zero.
            if (request.Valor <= 0)
            {
                throw new BusinessException(
                    "O valor deve ser maior que zero."
                );
            }

            // Busca a pessoa vinculada à transação.
            // Caso não exista, interrompe o cadastro.
            var pessoa = await context.Pessoas
                .FirstOrDefaultAsync(p => p.Id == request.PessoaId)
                ?? throw new NotFoundException("Pessoa não encontrada.");

            // Regra de negócio: menores de idade podem cadastrar apenas despesas.
            if (pessoa.Idade < 18 && request.Tipo == TipoTransacao.Receita)
            {
                throw new BusinessException(
                    "Pessoas menores de idade podem cadastrar apenas despesas.");
            }

            // Cria a entidade de transação associando os dados recebidos
            // com a pessoa previamente validada.
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


        // Método responsável por buscar todas as transações cadastradas.
        public async Task<IEnumerable<TransacaoResponse>> BuscarTodasAsync()
        {
            var transacoes = await context.Transacoes
                .AsNoTracking()
                .ToListAsync();

            return transacoes.Select(t => new TransacaoResponse(
                t.Id,
                t.Descricao,
                t.Valor,
                t.Tipo,
                t.PessoaId
            ));
        }


        // Busca uma transação pelo ID informado.
        // Caso não exista, dispara uma exceção de recurso não encontrado.
        public async Task<TransacaoResponse> BuscarPorIdAsync(Guid id)
        {
            var transacao = await context.Transacoes
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new NotFoundException("Transação não encontrada.");

            return new TransacaoResponse(
                transacao.Id,
                transacao.Descricao,
                transacao.Valor,
                transacao.Tipo,
                transacao.PessoaId
            );
        }


        // Remove uma transação pelo ID informado.
        // Caso não exista, dispara uma exceção de recurso não encontrado.
        public async Task RemoverAsync(Guid id)
        {
            var transacao = await context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new NotFoundException("Transação não encontrada.");

            context.Transacoes.Remove(transacao);

            await context.SaveChangesAsync();
        }
    }
}