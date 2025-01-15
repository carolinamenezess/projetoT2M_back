using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Models;

namespace Domain.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync(int usuarioId);
        Task<Categoria> GetByIdAsync(int categoriaId);

        Task<int> CreateAsync(CategoriaModel categoria);

        Task UpdateAsync(Categoria categoria);

        Task DeleteAsync(int categoriaId);
        Task<IEnumerable<Categoria>> GetByUserIdAsync(int userId,string nome);
    }
}
