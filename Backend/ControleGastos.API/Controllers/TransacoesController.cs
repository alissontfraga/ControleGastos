using ControleGastos.API.DTOs.Transacoes;
using ControleGastos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController(ITransacaoService transacaoService) : ControllerBase
    {

        //    Endpoint responsável por criar uma nova transação.
        //    Valida se a pessoa existe e aplica regras de negócio,
        //    como impedir receitas para menores de idade.
        [HttpPost]
        [ProducesResponseType(typeof(TransacaoResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransacaoResponse>> Criar(
            [FromBody] TransacaoRequest request)
        {
            var transacao = await transacaoService.CriarAsync(request);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = transacao.Id },
                transacao
            );
        }


        // Endpoint responsável por buscar todas as transações.
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransacaoResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransacaoResponse>>> BuscarTodas()
        {
            var transacoes = await transacaoService.BuscarTodasAsync();

            return Ok(transacoes);
        }


        // Endpoint responsável por buscar uma transação pelo ID.
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransacaoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransacaoResponse>> BuscarPorId(Guid id)
        {
            var transacao = await transacaoService.BuscarPorIdAsync(id);

            return Ok(transacao);
        }


        // Endpoint responsável por remover uma transação pelo ID.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remover(Guid id)
        {

            await transacaoService.RemoverAsync(id);

            return NoContent();
        }
    }
}