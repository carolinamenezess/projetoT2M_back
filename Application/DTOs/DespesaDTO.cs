using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DespesaDTO
    {
        public int DespesaId { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }

        public double Valor { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
    }

}
