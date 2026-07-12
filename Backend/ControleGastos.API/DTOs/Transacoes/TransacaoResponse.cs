using ControleGastos.API.Enums;

namespace ControleGastos.API.DTOs.Transacoes
{
    // DTO responsável por representar os dados de uma transação
    // retornados pela API.
    public record TransacaoResponse(
        Guid Id,
        string Descricao,
        decimal Valor,
        TipoTransacao Tipo,
        Guid PessoaId
    );
}