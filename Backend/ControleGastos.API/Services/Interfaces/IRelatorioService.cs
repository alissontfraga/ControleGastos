using ControleGastos.API.DTOs.Relatorios;

namespace ControleGastos.API.Services.Interfaces
{
    public interface IRelatorioService
    {
        // Método responsável por calcular o resumo dos gastos
        Task<ResumoGastosResponse> ObterResumoAsync();
    }
}