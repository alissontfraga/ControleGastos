using ControleGastos.API.Data;
using ControleGastos.API.DTOs.Transacoes;
using ControleGastos.API.Models;
using ControleGastos.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services
{
    public class TransacaoService(AppDbContext context) : ITransacaoService
    {
        private readonly AppDbContext _context = context;

        // Método responsável por criar uma nova transação
        public async Task<TransacaoResponse> CriarAsync(TransacaoRequest request)
        {
            var pessoaExiste = await _context.Pessoas
                .AnyAsync(p => p.Id == request.PessoaId);

            if (!pessoaExiste)
                throw new Exception("Pessoa não encontrada.");

            var transacao = new Transacao
            {
                Id = Guid.NewGuid(),
                Descricao = request.Descricao,
                Valor = request.Valor,
                Tipo = request.Tipo,
                PessoaId = request.PessoaId
            };

            await _context.Transacoes.AddAsync(transacao);

            await _context.SaveChangesAsync();

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
            var transacoes = await _context.Transacoes
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
        public async Task<TransacaoResponse?> BuscarPorIdAsync(Guid id)
        {
            var transacao = await _context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transacao is null)
                return null;

            return new TransacaoResponse(
                transacao.Id,
                transacao.Descricao,
                transacao.Valor,
                transacao.Tipo,
                transacao.PessoaId
            );
        }

        // Método responsável por remover uma transação por ID
        public async Task<bool> RemoverAsync(Guid id)
        {
            var transacao = await _context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transacao is null)
                return false;

            _context.Transacoes.Remove(transacao);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}