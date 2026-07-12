using ControleGastos.API.DTOs.Pessoas;

namespace ControleGastos.API.Services.Interfaces
{
    // Contrato que define as operações disponíveis
    // para gerenciamento de pessoas.
    public interface IPessoaService
    {
        // Cria uma nova pessoa a partir dos dados recebidos.
        Task<PessoaResponse> CriarAsync(PessoaRequest request);

        // Retorna todas as pessoas cadastradas.
        Task<IEnumerable<PessoaResponse>> BuscarTodasAsync();

        // Busca uma pessoa pelo ID informado.
        // Caso não exista, a implementação deve tratar o recurso não encontrado.
        Task<PessoaResponse> BuscarPorIdAsync(Guid id);

        // Remove uma pessoa pelo ID informado.
        // A implementação também deve remover suas transações relacionadas.
        Task RemoverAsync(Guid id);
    }
}