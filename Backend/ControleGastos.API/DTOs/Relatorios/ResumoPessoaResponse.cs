namespace ControleGastos.API.DTOs.Relatorios
{
    // DTO responsável por representar o resumo financeiro individual de uma pessoa.
    // Contém os totais de receitas, despesas e saldo calculado.
    public record ResumoPessoaResponse(
        Guid Id,
        string Nome,
        decimal TotalReceitas,
        decimal TotalDespesas,
        decimal Saldo
    );
}