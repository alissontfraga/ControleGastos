using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleGastos.API.DTOs.Transacoes;

namespace ControleGastos.API.Services.Interfaces
{
    public interface ITransacaoService
    {
    // Método responsável por criar uma nova transação
    Task<TransacaoResponse> CriarAsync(TransacaoRequest request);

    // Método responsável por buscar todas as transações
    Task<IEnumerable<TransacaoResponse>> BuscarTodasAsync();

    // Método responsável por buscar uma transação por ID
    Task<TransacaoResponse> BuscarPorIdAsync(Guid id);

    // Método responsável por remover uma transação por ID
    Task RemoverAsync(Guid id);
    }
}