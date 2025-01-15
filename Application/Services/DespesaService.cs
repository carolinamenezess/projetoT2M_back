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
    public class DespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public DespesaService(IDespesaRepository despesaRepository, IUsuarioRepository usuarioRepository)
        {
            _despesaRepository = despesaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> CriarDespesaAsync(DespesaDTO despesaDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(despesaDto.UsuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado.");

            var despesa = new DespesaModel(despesaDto.Categoria,despesaDto.Nome, despesaDto.Valor, despesaDto.UsuarioId);
            return await _despesaRepository.CreateAsync(despesa);
        }
        public async Task<DespesaDTO> ObterDespesaPorIdAsync(int despesaId)
        {
            var despesa = await _despesaRepository.GetByIdAsync(despesaId);
            if (despesa == null) return null;

            return new DespesaDTO
            {
                DespesaId = despesa.DespesaId,
                Categoria = despesa.Categoria,
                Nome = despesa.Nome,
                Valor = despesa.Valor,
                UsuarioId = despesa.UsuarioId,
                DataCriacao = despesa.DataCriacao
            };
        }

        public async Task<IEnumerable<DespesaDTO>> ObterDespesasPorUsuarioAsync(int usuarioId)
        {
            var despesas = await _despesaRepository.GetByUserIdAsync(usuarioId);
            return despesas.Select(despesa => new DespesaDTO
            {
                DespesaId = despesa.DespesaId,
                Categoria = despesa.Categoria,
                Nome = despesa.Nome,
                Valor = despesa.Valor,
                UsuarioId = despesa.UsuarioId,
                DataCriacao = despesa.DataCriacao
            });
        }

        public async Task<bool> AtualizarDespesaAsync(int despesaId, string categoria,string nome, double valor)
        {
            var despesa = await _despesaRepository.GetByIdAsync(despesaId);
            if (despesa == null)
                return false ;

            despesa.Categoria = categoria;
            despesa.Nome = nome;
            despesa.Valor = valor;


             await _despesaRepository.UpdateAsync(despesa);
            return true;
        }
        public async Task<bool> DeletarDespesaAsync(int despesaId)
        {
             await _despesaRepository.DeleteAsync(despesaId);
            return true;
        }
    
      public async Task<double> SumValues(int userId)
        {
        
            return await _despesaRepository.SumValues(userId); ;
        }

        public async Task<IEnumerable<DespesaCategoria>> GetValuesCategoria(int userId)
        {

            return await _despesaRepository.GetValuesCategoria(userId); ;
        }

    }
    
}
