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
using Npgsql;

namespace Infrastructure.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly IDbConnection _dbConnection;

        public ReceitaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Receita> GetByIdAsync(int receitaId)
        {
            var query = "SELECT receita_id, categoria, nome, valor, user_id, data_criacao FROM receitas WHERE receita_id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Receita>(query, new { Id = receitaId });
        }

        public async Task<int> CreateAsync(ReceitaModel receita)
        {
            var query = "INSERT INTO receitas (categoria,nome, valor, user_id) VALUES (@Categoria,@Nome, @Valor, @UsuarioId) RETURNING receita_id";
            return await _dbConnection.QuerySingleAsync<int>(query, receita);
        }
        public async Task UpdateAsync(Receita receita)
        {
            var query = "UPDATE receitas SET categoria = @Categoria,nome = @Nome, valor = @Valor WHERE receita_id = @ReceitaId";
            await _dbConnection.ExecuteAsync(query, receita);
        }

        public async Task DeleteAsync(int receitaId)
        {
            var query = "DELETE FROM receitas WHERE receita_id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = receitaId });
        }
        public async Task<IEnumerable<Receita>> GetByUserIdAsync(int userId)
        {
            var query = "SELECT  receita_id, categoria,nome, valor, user_id, data_criacao FROM receitas WHERE user_id = @UserId ORDER BY data_criacao DESC";
            return await _dbConnection.QueryAsync<Receita>(query, new { UserId = userId });
        }
        public async Task<double> SumValues(int userId)
        {
            var query = "SELECT SUM(valor) FROM receitas WHERE user_id = @UserId";

            double total = _dbConnection.ExecuteScalar<double>(query, new { UserId = userId });

            return total;
        }
    }
}
