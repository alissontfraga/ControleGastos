namespace ControleGastos.API.DTOs.Relatorios
{
    public record ResumoGeralResponse(
        IEnumerable<ResumoPessoaResponse> Pessoas,
        decimal TotalReceitas,
        decimal TotalDespesas,
        decimal Saldo
    );
}