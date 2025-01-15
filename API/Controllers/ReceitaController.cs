using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitaService _receitaService;

        public ReceitasController(ReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReceitaDTO receitaDto)
        {
            var receitaId = await _receitaService.CriarReceitaAsync(receitaDto.Categoria, receitaDto.Nome, receitaDto.Valor, receitaDto.UsuarioId);
            return Ok(receitaId);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId)
        {
            var receitas = await _receitaService.ObterReceitasPorUsuarioAsync(usuarioId);
            return Ok(receitas);
        }

        [HttpGet("{receitaId}")]
        public async Task<IActionResult> GetById(int receitaId)
        {
            var receita = await _receitaService.ObterReceitaPorIdAsync(receitaId);
            if (receita == null)
                return NotFound();
            return Ok(receita);
        }

        [HttpGet("valor/{usuarioId}")]
        public async Task<IActionResult> GetSumValues(int usuarioId)
        {
            var soma = await _receitaService.SumValues(usuarioId);
            return Ok(soma);
        }

        [HttpPut("{receitaId}")]
        public async Task<IActionResult> Update(int receitaId, [FromBody] ReceitaDTO receitaDto)
        {
            var sucesso = await _receitaService.AtualizarReceitaAsync(receitaId, receitaDto.Categoria, receitaDto.Nome, receitaDto.Valor);
            if (sucesso)
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{receitaId}")]
        public async Task<IActionResult> Delete(int receitaId)
        {
            var sucesso = await _receitaService.DeletarReceitaAsync(receitaId);
            if (sucesso)
                return NoContent();
            return NotFound();
        }
    }
}
