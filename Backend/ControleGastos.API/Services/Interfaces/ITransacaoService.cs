using ControleGastos.API.DTOs.Transacoes;

namespace ControleGastos.API.Services.Interfaces
{
    // Contrato que define as operações disponíveis
    // para gerenciamento de transações.
    public interface ITransacaoService
    {
        // Cria uma nova transação.
        // A implementação deve validar a existência da pessoa
        // e aplicar as regras de negócio relacionadas.
        Task<TransacaoResponse> CriarAsync(TransacaoRequest request);

        // Retorna todas as transações cadastradas.
        Task<IEnumerable<TransacaoResponse>> BuscarTodasAsync();

        // Busca uma transação pelo ID informado.
        // Caso não exista, a implementação deve tratar o recurso não encontrado.
        Task<TransacaoResponse> BuscarPorIdAsync(Guid id);

        // Remove uma transação pelo ID informado.
        Task RemoverAsync(Guid id);
    }
}