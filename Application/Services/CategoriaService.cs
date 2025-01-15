using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entity;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IUsuarioRepository usuarioRepository)
        {
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> CriarDespesaAsync(CategoriaDTO categoriaDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(categoriaDto.UsuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado.");

            var categoria = new CategoriaModel(categoriaDto.Nome, categoriaDto.UsuarioId, categoriaDto.Tipo);
            return await _categoriaRepository.CreateAsync(categoria);
        }
        public async Task<CategoriaDTO> ObterDespesaPorIdAsync(int categoriaId)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(categoriaId);
            if (categoria == null) return null;

            return new CategoriaDTO
            {
                CategoriaId = categoria.CategoriaId,
                Nome = categoria.Nome,
                UsuarioId = categoria.UsuarioId,
                Tipo = categoria.Tipo,
                DataCriacao = categoria.DataCriacao
            };
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterDespesasPorUsuarioAsync(int usuarioId,string nome)
        {
            var categorias = await _categoriaRepository.GetByUserIdAsync(usuarioId, nome);
            return categorias.Select(categoria => new CategoriaDTO
            {
                CategoriaId = categoria.CategoriaId,
                Nome = categoria.Nome,
                UsuarioId = categoria.UsuarioId,
                Tipo = categoria.Tipo,
                DataCriacao = categoria.DataCriacao
            });
        }

        public async Task<bool> AtualizarCategoriaAsync(int categoriaId, string nome, string tipo)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(categoriaId);
            if (categoria == null)
                return false;

            categoria.Nome = nome;
            categoria.Tipo = tipo;

            await _categoriaRepository.UpdateAsync(categoria);
            return true;
        }
        public async Task<bool> DeletarDespesaAsync(int categoriaId)
        {
            await _categoriaRepository.DeleteAsync(categoriaId);
            return true;
        }
    }
}
