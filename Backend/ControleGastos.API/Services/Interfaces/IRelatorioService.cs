using ControleGastos.API.DTOs.Relatorios;

namespace ControleGastos.API.Services.Interfaces
{
    // Contrato que define as operações relacionadas
    // aos relatórios financeiros do sistema.
    public interface IRelatorioService
    {
        // Retorna o resumo financeiro contendo:
        // - receitas por pessoa;
        // - despesas por pessoa;
        // - saldo individual;
        // - totais gerais do sistema.
        Task<ResumoGeralResponse> ObterResumoAsync();
    }
}