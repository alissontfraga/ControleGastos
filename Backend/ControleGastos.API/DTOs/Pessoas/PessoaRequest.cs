using System.ComponentModel.DataAnnotations;

namespace ControleGastos.API.DTOs.Pessoas
{
    public record PessoaRequest
    (
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        string Nome,

        [Required(ErrorMessage = "A idade é obrigatória.")]
        [Range(1, 110, ErrorMessage = "A idade deve estar entre 1 e 110 anos.")]
        int Idade
    );
}