using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }

        public Categoria(int categoria_id, string nome,string tipo, int user_id, DateTime data_criacao)
        {
            CategoriaId = categoria_id;
            Tipo = tipo;
            Nome = nome;
            UsuarioId = user_id;
            DataCriacao = data_criacao;
        }
    }
}
