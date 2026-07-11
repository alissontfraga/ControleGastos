using ControleGastos.API.DTOs.Transacoes;
using ControleGastos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController(ITransacaoService transacaoService) : ControllerBase
    {
        private readonly ITransacaoService _transacaoService = transacaoService;


        // Endpoint responsável por criar uma nova transação
        [HttpPost]
        public async Task<ActionResult<TransacaoResponse>> Criar(TransacaoRequest request)
        {
            var transacao = await _transacaoService.CriarAsync(request);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = transacao.Id },
                transacao
            );
        }


        // Endpoint responsável por buscar todas as transações
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoResponse>>> BuscarTodas()
        {
            var transacoes = await _transacaoService.BuscarTodasAsync();

            return Ok(transacoes);
        }


        // Endpoint responsável por buscar uma transação por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TransacaoResponse>> BuscarPorId(Guid id)
        {
            var transacao = await _transacaoService.BuscarPorIdAsync(id);

            if (transacao is null)
                return NotFound();

            return Ok(transacao);
        }


        // Endpoint responsável por remover uma transação por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var removido = await _transacaoService.RemoverAsync(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}