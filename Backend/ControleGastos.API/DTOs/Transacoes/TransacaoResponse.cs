namespace ControleGastos.API.DTOs.Transacoes;

using ControleGastos.API.Enums;

public record TransacaoResponse(
    Guid Id,
    string Descricao,
    decimal Valor,
    TipoTransacao Tipo,
    Guid PessoaId
);