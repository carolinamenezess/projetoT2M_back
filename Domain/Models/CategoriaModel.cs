using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CategoriaModel
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }

        public CategoriaModel(string nome, int user_id, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
            UsuarioId = user_id;
            DataCriacao = DateTime.UtcNow;
        }
    }
}
