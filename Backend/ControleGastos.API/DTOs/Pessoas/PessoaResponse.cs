namespace ControleGastos.API.DTOs.Pessoas
{
    // DTO responsável por representar os dados de uma pessoa
    // retornados pela API.
    public record PessoaResponse(
        Guid Id,
        string Nome,
        int Idade
    );
}