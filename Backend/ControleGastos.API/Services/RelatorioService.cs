using ControleGastos.API.Data;
using ControleGastos.API.DTOs.Relatorios;
using ControleGastos.API.Enums;
using ControleGastos.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services
{
    public class RelatorioService(AppDbContext context) : IRelatorioService
    {
        // Método responsável por retornar o resumo geral dos gastos
        public async Task<ResumoGeralResponse> ObterResumoAsync()
        {
            var pessoas = await context.Pessoas
                .Include(p => p.Transacoes)
                .ToListAsync();

            var resumoPessoas = pessoas.Select(p =>
            {
                var totalReceitas = p.Transacoes
                    .Where(t => t.Tipo == TipoTransacao.Receita)
                    .Sum(t => t.Valor);

                var totalDespesas = p.Transacoes
                    .Where(t => t.Tipo == TipoTransacao.Despesa)
                    .Sum(t => t.Valor);

                return new ResumoPessoaResponse(
                    p.Id,
                    p.Nome,
                    totalReceitas,
                    totalDespesas,
                    totalReceitas - totalDespesas
                );
            }).ToList();

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