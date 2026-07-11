using ControleGastos.API.DTOs.Pessoas;
using ControleGastos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController(IPessoaService pessoaService) : ControllerBase
    {

        // Método post pra criar uma pessoa
        [HttpPost]
        public async Task<ActionResult<PessoaResponse>> Criar(PessoaRequest request)
        {
            var pessoa = await pessoaService.CriarAsync(request);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = pessoa.Id},
                pessoa
            );
        }

        // Método get pra buscar uma pessoa por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaResponse>> BuscarPorId(Guid id)
        {
            var pessoa = await pessoaService.BuscarPorIdAsync(id);

            if (pessoa is null)
                return NotFound();

            return Ok(pessoa);
        }

        // Método get pra buscar todas as pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaResponse>>> BuscarTodas()
        {
            var pessoas = await pessoaService.BuscarTodasAsync();

            return Ok(pessoas);
        }

        // Método delete pra excluir uma pessoa por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var removido = await pessoaService.RemoverAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }

    }
}