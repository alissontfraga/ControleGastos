namespace ControleGastos.API.DTOs.Transacoes;

using ControleGastos.API.Enums;

public record TransacaoRequest(
    string Descricao,
    decimal Valor,
    TipoTransacao Tipo,
    Guid PessoaId
);