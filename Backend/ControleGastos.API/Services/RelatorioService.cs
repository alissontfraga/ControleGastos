using ControleGastos.API.Data;
using ControleGastos.API.DTOs.Relatorios;
using ControleGastos.API.Enums;
using ControleGastos.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services
{
    public class RelatorioService(AppDbContext context) : IRelatorioService
    {
        // Método responsável por gerar o resumo financeiro.
        // Retorna os totais de receitas, despesas e saldo de cada pessoa,
        // além dos totais gerais considerando todas as pessoas cadastradas.
        public async Task<ResumoGeralResponse> ObterResumoAsync()
        {
            // Busca todas as pessoas junto com suas respectivas transações
            // para realizar os cálculos individuais e gerais.
            var pessoas = await context.Pessoas
                .Include(p => p.Transacoes)
                .AsNoTracking()
                .ToListAsync();

            // Calcula os totais financeiros de cada pessoa cadastrada.
            var resumoPessoas = pessoas.Select(p =>
            {
                // Soma apenas as transações classificadas como receitas.
                var totalReceitas = p.Transacoes
                    .Where(t => t.Tipo == TipoTransacao.Receita)
                    .Sum(t => t.Valor);

                // Soma apenas as transações classificadas como despesas.
                var totalDespesas = p.Transacoes
                    .Where(t => t.Tipo == TipoTransacao.Despesa)
                    .Sum(t => t.Valor);

                // O saldo é calculado pela diferença entre receitas e despesas.
                return new ResumoPessoaResponse(
                    p.Id,
                    p.Nome,
                    totalReceitas,
                    totalDespesas,
                    totalReceitas - totalDespesas
                );
            }).ToList();

            // Calcula os totais gerais considerando todas as pessoas.
            var totalReceitasGeral = resumoPessoas.Sum(p => p.TotalReceitas);

            var totalDespesasGeral = resumoPessoas.Sum(p => p.TotalDespesas);

            return new ResumoGeralResponse(
                resumoPessoas,
                totalReceitasGeral,
                totalDespesasGeral,
                totalReceitasGeral - totalDespesasGeral
            );
        }
    }
}