namespace ControleGastos.API.DTOs.Relatorios
{
    // DTO responsável por representar o resumo financeiro completo do sistema.
    // Contém os dados individuais de cada pessoa e os totais gerais.
    public record ResumoGeralResponse(
        IEnumerable<ResumoPessoaResponse> Pessoas,
        decimal TotalReceitas,
        decimal TotalDespesas,
        decimal Saldo
    );
}