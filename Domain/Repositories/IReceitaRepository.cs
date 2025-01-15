using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IReceitaRepository
    {
        Task<Receita> GetByIdAsync(int receitaId);
        Task<int> CreateAsync(ReceitaModel receita);
        Task UpdateAsync(Receita receita);
        Task DeleteAsync(int receitaId);
        Task<IEnumerable<Receita>> GetByUserIdAsync(int userId);
        Task<double> SumValues(int userId);

    }
}
