using ControleGastos.API.DTOs.Relatorios;

namespace ControleGastos.API.Services.Interfaces
{
    public interface IRelatorioService
    {
        // Contrato responsável por retornar o resumo geral dos gastos
        Task<ResumoGeralResponse> ObterResumoAsync();
    }
}