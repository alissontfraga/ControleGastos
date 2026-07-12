using System.ComponentModel.DataAnnotations;
using ControleGastos.API.Enums;

namespace ControleGastos.API.DTOs.Transacoes
{
    // DTO responsável por receber os dados necessários
    // para criação de uma nova transação.
    public record TransacaoRequest
    (
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres.")]
        string Descricao,

        [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "O valor deve ser maior que zero.")]
        decimal Valor,

        [Required(ErrorMessage = "O tipo da transação é obrigatório.")]
        TipoTransacao Tipo,

        [Required(ErrorMessage = "A pessoa é obrigatória.")]
        Guid PessoaId
    );
}