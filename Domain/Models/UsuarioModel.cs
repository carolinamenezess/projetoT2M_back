using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public DateTime DataCriacao { get; set; }

        public UsuarioModel(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            DataCriacao = DateTime.UtcNow;
            Senha = senha;
        }
    }
}
