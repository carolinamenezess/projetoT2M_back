using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DespesaModel
    {
        public int DespesaId { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }

        public double Valor { get; set; }

        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }

        public DespesaModel(string categoria, string nome, double valor, int usuarioId)
        {

            Categoria = categoria;
            Nome = nome;
            Valor = valor;
            UsuarioId = usuarioId;
            DataCriacao = DateTime.UtcNow;
        }
    }
}
