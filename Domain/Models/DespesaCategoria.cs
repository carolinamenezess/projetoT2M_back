using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DespesaCategoria
    {
        public string Categoria { get; set; }
        public double ValorTotal { get; set; }
    
        public DespesaCategoria(string categoria, double valorTotal)
        {
            Categoria = categoria;
            ValorTotal = valorTotal;
        }
    }
}
