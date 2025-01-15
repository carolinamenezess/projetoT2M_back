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
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> CriarUsuarioAsync(string nome, string email,string senha)
        {
            var usuario = new UsuarioModel(nome, email,senha);
            return await _usuarioRepository.CreateAsync(usuario);
        }

        public async Task<UsuarioDTO> ObterUsuarioPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(usuario => new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            });
        }
    }
}
