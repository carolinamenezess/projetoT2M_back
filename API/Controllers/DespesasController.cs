using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly DespesaService _despesaService;

        public DespesasController(DespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DespesaDTO despesaDto)
        {
            var despesaId = await _despesaService.CriarDespesaAsync(despesaDto);
            return Ok(despesaId);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId)
        {
            var despesas = await _despesaService.ObterDespesasPorUsuarioAsync(usuarioId);
            return Ok(despesas);
        }
        [HttpGet("valor/{usuarioId}")]
        public async Task<IActionResult> GetSumValues(int usuarioId)
        {
            var soma = await _despesaService.SumValues(usuarioId);
            return Ok(soma);
        }

        [HttpGet("valor-categoria/{usuarioId}")]
        public async Task<IActionResult> GetValuesCategoria(int usuarioId)
        {
            var soma = await _despesaService.GetValuesCategoria(usuarioId);
            return Ok(soma);
        }

        [HttpGet("{despesaId}")]
        public async Task<IActionResult> GetById(int despesaId)
        {
            var despesa = await _despesaService.ObterDespesaPorIdAsync(despesaId);
            if (despesa == null)
                return NotFound();
            return Ok(despesa);
        }

        [HttpPut("{despesaId}")]
        public async Task<IActionResult> Update(int despesaId, [FromBody] DespesaDTO despesaDto)
        {
            var sucesso = await _despesaService.AtualizarDespesaAsync(despesaId, despesaDto.Categoria,despesaDto.Nome, despesaDto.Valor);
            if (sucesso)
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{despesaId}")]
        public async Task<IActionResult> Delete(int despesaId)
        {
            var sucesso = await _despesaService.DeletarDespesaAsync(despesaId);
            if (sucesso)
                return NoContent();
            return NotFound();
        }
    }
}
