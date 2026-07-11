using ControleGastos.API.Data;
using ControleGastos.API.DTOs.Relatorios;
using ControleGastos.API.Enums;
using ControleGastos.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.Services
{
    public class RelatorioService(AppDbContext context) : IRelatorioService
    {
        // Método responsável por calcular o resumo dos gastos
        public async Task<ResumoGastosResponse> ObterResumoAsync()
        {
            var transacoes = await context.Transacoes
                .ToListAsync();

            var totalReceitas = transacoes
                .Where(t => t.Tipo == TipoTransacao.Receita)
                .Sum(t => t.Valor);

            var totalDespesas = transacoes
                .Where(t => t.Tipo == TipoTransacao.Despesa)
                .Sum(t => t.Valor);

            var saldo = totalReceitas - totalDespesas;

            return new ResumoGastosResponse(
                totalReceitas,
                totalDespesas,
                saldo
            );
        }
    }
}