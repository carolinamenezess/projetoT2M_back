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
    public class DespesaRepository : IDespesaRepository
    {
        private readonly IDbConnection _dbConnection;

        public DespesaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
      
        public async Task<Despesa> GetByIdAsync(int despesaId)
        {
            var query = "SELECT despesa_id, categoria,nome, valor, user_id, data_criacao FROM despesas WHERE despesa_id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Despesa>(query, new { Id = despesaId });
        }
        public async Task<int> CreateAsync(DespesaModel despesa)
        {
            var query = "INSERT INTO despesas (categoria,nome, valor, user_id) VALUES (@Categoria,@Nome, @Valor, @UsuarioId) RETURNING despesa_id";
            return await _dbConnection.QuerySingleAsync<int>(query, despesa);
        }
        public async Task UpdateAsync(Despesa despesa)
        {
            var query = "UPDATE despesas SET categoria = @Categoria, nome = @Nome, valor = @Valor WHERE despesa_id = @DespesaId";
            await _dbConnection.ExecuteAsync(query, despesa);
        }

        public async Task DeleteAsync(int despesaId)
        {
            var query = "DELETE FROM despesas WHERE despesa_id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = despesaId });
        }
        public async Task<IEnumerable<Despesa>> GetByUserIdAsync(int userId)
        {
            var query = "SELECT  despesa_id, categoria,nome, valor, user_id, data_criacao FROM despesas WHERE user_id = @UserId ORDER BY data_criacao DESC";
            return await _dbConnection.QueryAsync<Despesa>(query, new { UserId = userId });
        }

        public async Task<double> SumValues(int userId)
        {
            var query = "SELECT SUM(valor) FROM despesas WHERE user_id = @UserId";
           
            double total =  _dbConnection.ExecuteScalar<double>(query, new { UserId = userId });

            return total;
        }

        public async Task<IEnumerable<DespesaCategoria>> GetValuesCategoria(int userId)
        {
            var query = "SELECT  categoria, COALESCE(SUM(valor), 0) AS valorTotal FROM despesas WHERE user_id = @UserId GROUP BY categoria ORDER BY categoria";

            return await _dbConnection.QueryAsync<DespesaCategoria>(query, new { UserId = userId });
        }
    }
}
