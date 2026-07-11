using ControleGastos.API.DTOs.Pessoas;

namespace ControleGastos.API.Services.Interfaces
{
    // Contrato dos serviços relacionados a Pessoa
    public interface IPessoaService
    {

        // Método de criação de pessoa
        Task<PessoaResponse> CriarAsync(PessoaRequest request);

        //Método de busca de todas as pessoas
        Task<IEnumerable<PessoaResponse>> BuscarTodasAsync();

        // Método de busca de pessoa por ID
        Task<PessoaResponse?> BuscarPorIdAsync(Guid id);

        // Método de exclusão de pessoa
        Task<bool> RemoverAsync(Guid id);
    }
}