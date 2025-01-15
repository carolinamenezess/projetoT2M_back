using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IDespesaRepository
    {
        Task<Despesa> GetByIdAsync(int despesaId);

        Task<int> CreateAsync(DespesaModel despesa);

        Task UpdateAsync(Despesa despesa);

        Task DeleteAsync(int despesaId);
        Task<IEnumerable<Despesa>> GetByUserIdAsync(int userId);
        Task<double> SumValues(int userId);
        Task<IEnumerable<DespesaCategoria>> GetValuesCategoria(int userId);



        




    }
}
