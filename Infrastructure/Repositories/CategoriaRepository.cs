using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Entity;
using Domain.Models;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoriaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync(int usuarioId)
        {
            var query = "SELECT  categoria_id, nome,tipo, user_id, data_criacao FROM categorias WHERE user_id = @UsuarioId";
            return await _dbConnection.QueryAsync<Categoria>(query, new { UsuarioId = usuarioId });
        }

        public async Task<Categoria> GetByIdAsync(int categoriaId)
        {
            var query = "SELECT categoria_id, nome,tipo, user_id, data_criacao FROM categorias WHERE categoria_id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Categoria>(query, new { Id = categoriaId });
        }

        public async Task<int> CreateAsync(CategoriaModel despesa)
        {
            var query = "INSERT INTO categorias (nome,tipo, user_id) VALUES (@Nome,@Tipo, @UsuarioId) RETURNING categoria_id";
            return await _dbConnection.QuerySingleAsync<int>(query, despesa);
        }

        public async Task UpdateAsync(Categoria despesa)
        {
            var query = "UPDATE categorias SET nome = @Nome,tipo = @Tipo WHERE categoria_id = @categoriaId";
            await _dbConnection.ExecuteAsync(query, despesa);
        }

        public async Task DeleteAsync(int categoriaId)
        {
            var query = "DELETE FROM categorias WHERE categoria_id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = categoriaId });
        }
        public async Task<IEnumerable<Categoria>> GetByUserIdAsync(int userId, string nome)
        {
            var query = "SELECT  categoria_id, nome,tipo, user_id, data_criacao FROM categorias WHERE user_id = @UserId AND tipo = @Tipo";
            return await _dbConnection.QueryAsync<Categoria>(query, new { UserId = userId, Tipo = nome });
        }
    }
}
