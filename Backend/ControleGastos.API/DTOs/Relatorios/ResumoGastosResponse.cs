namespace ControleGastos.API.DTOs.Relatorios
{
    public record ResumoGastosResponse(
        decimal TotalReceitas,
        decimal TotalDespesas,
        decimal Saldo
    );
}