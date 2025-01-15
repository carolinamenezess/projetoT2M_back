using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class DespesaReturn
    {
        public int DespesaId { get; set; }
        public string Categoria { get; set; }
        public float Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }

        
    }
}
