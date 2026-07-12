using System.ComponentModel.DataAnnotations;

namespace ControleGastos.API.DTOs.Pessoas
{
    // DTO responsável por receber os dados necessários
    // para cadastro de uma nova pessoa.
    public record PessoaRequest
    (
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        [MinLength(2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres.")]
        string Nome,

        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(1, 110, ErrorMessage = "A idade deve estar entre 1 e 110 anos.")]
        int Idade
    );
}