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
    public class ReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ReceitaService(IReceitaRepository receitaRepository, IUsuarioRepository usuarioRepository)
        {
            _receitaRepository = receitaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> CriarReceitaAsync(string categoria, string nome, double valor, int usuarioId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado.");

            var receita = new ReceitaModel(categoria,nome, valor, usuarioId);
            return await _receitaRepository.CreateAsync(receita);
        }
        public async Task<ReceitaDTO> ObterReceitaPorIdAsync(int receitaId)
        {
            var receita = await _receitaRepository.GetByIdAsync(receitaId);
            if (receita == null) return null;

            return new ReceitaDTO
            {
                ReceitaId = receita.ReceitaId,
                Categoria = receita.Categoria,
                Nome = receita.Nome,
                Valor = receita.Valor,
                UsuarioId = receita.UsuarioId,
                DataCriacao = receita.DataCriacao,
            };
        }

        public async Task<IEnumerable<ReceitaDTO>> ObterReceitasPorUsuarioAsync(int usuarioId)
        {
            var receitas = await _receitaRepository.GetByUserIdAsync(usuarioId);
            return receitas.Select(receita => new ReceitaDTO
            {
                ReceitaId = receita.ReceitaId,
                Categoria = receita.Categoria,
                Nome = receita.Nome,
                Valor = receita.Valor,
                DataCriacao = receita.DataCriacao,
                UsuarioId = receita.UsuarioId,
            });
        }

        public async Task<bool> AtualizarReceitaAsync(int receitaId, string categoria,string nome, double valor)
        {
            var receita = await _receitaRepository.GetByIdAsync(receitaId);
            if (receita == null)
                return false;

            receita.Categoria = categoria;
            receita.Nome = nome;
            receita.Valor = valor;

            await _receitaRepository.UpdateAsync(receita);
            return true;
        }

        public async Task<bool> DeletarReceitaAsync(int receitaId)
        {
            await _receitaRepository.DeleteAsync(receitaId);
            return true;
        }
        public async Task<double> SumValues(int userId)
        {

            return await _receitaRepository.SumValues(userId); ;
        }
    }
}
