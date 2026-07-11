using ControleGastos.API.DTOs.Pessoas;
using ControleGastos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController(IPessoaService pessoaService) : ControllerBase
    {

        // Endpoint responsável por criar uma nova pessoa
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

        // Endpoint responsável por buscar uma pessoa pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaResponse>> BuscarPorId(Guid id)
        {
            var pessoa = await pessoaService.BuscarPorIdAsync(id);

            return Ok(pessoa);
        }

        // Endpoint responsável por buscar todas as pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaResponse>>> BuscarTodas()
        {
            var pessoas = await pessoaService.BuscarTodasAsync();

            return Ok(pessoas);
        }

        // Endpoint responsável por remover uma pessoa pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
           
           await pessoaService.RemoverAsync(id); 
           
            return NoContent();
        }

    }
}