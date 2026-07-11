namespace ControleGastos.API.DTOs.Relatorios
{
    public record ResumoPessoaResponse(
        Guid Id,
        string Nome,
        decimal TotalReceitas,
        decimal TotalDespesas,
        decimal Saldo
    );
}