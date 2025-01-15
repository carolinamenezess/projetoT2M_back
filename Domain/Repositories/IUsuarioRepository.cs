using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int usuarioId);
        Task<int> CreateAsync(UsuarioModel usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int usuarioId);
    }
}
