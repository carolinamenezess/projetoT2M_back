using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaDTO categoriaDto)
        {
            var categoriaId = await _categoriaService.CriarDespesaAsync(categoriaDto);
            return Ok(categoriaId);
        }

        [HttpGet("usuario/{usuarioId}/{nome}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId,string nome)
        {
            var categorias = await _categoriaService.ObterDespesasPorUsuarioAsync(usuarioId, nome);
            return Ok(categorias);
        }

        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> GetById(int categoriaId)
        {
            var categoria = await _categoriaService.ObterDespesaPorIdAsync(categoriaId);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpPut("{categoriaId}")]
        public async Task<IActionResult> Update(int categoriaId, [FromBody] CategoriaDTO despesaDto)
        {
            var sucesso = await _categoriaService.AtualizarCategoriaAsync(categoriaId, despesaDto.Nome,despesaDto.Tipo);
            if (sucesso)
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{despesaId}")]
        public async Task<IActionResult> Delete(int despesaId)
        {
            var sucesso = await _categoriaService.DeletarDespesaAsync(despesaId);
            if (sucesso)
                return NoContent();
            return NotFound();
        }
    }
}
