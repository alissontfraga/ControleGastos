using ControleGastos.API.DTOs.Relatorios;
using ControleGastos.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController(IRelatorioService relatorioService) : ControllerBase
    {

        // Endpoint responsável por retornar o resumo dos gastos
        [HttpGet("resumo")]
        [ProducesResponseType(typeof(ResumoGeralResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResumoGeralResponse>> ObterResumo()
        {
            var resumo = await relatorioService.ObterResumoAsync();

            return Ok(resumo);
        }
    }
}