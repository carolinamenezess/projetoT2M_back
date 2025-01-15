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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;
        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<Usuario> GetByEmailAsync(string email)
        {
            var query = "SELECT usuario_id, nome, email, senha, data_criacao FROM usuarios WHERE email = @Email";
            return await _dbConnection.QuerySingleOrDefaultAsync<Usuario>(query, new { Email = email });
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var query = "SELECT * FROM usuarios";
            return await _dbConnection.QueryAsync<Usuario>(query);
        }
        public async Task<Usuario> GetByIdAsync(int usuarioId)
        {
            var query = "SELECT usuario_id, nome, email, senha, data_criacao FROM usuarios WHERE usuario_id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Usuario>(query, new { Id = usuarioId });
        }
        public async Task<int> CreateAsync(UsuarioModel usuario)
        {
            var query = "INSERT INTO usuarios (nome, email,senha) VALUES (@Nome, @Email,@Senha) RETURNING usuario_id";
            return await _dbConnection.QuerySingleAsync<int>(query, usuario);
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            var query = "UPDATE usuarios SET nome = @Nome, email = @Email WHERE usuario_id = @UsuarioId";
            await _dbConnection.ExecuteAsync(query, usuario);
        }
        public async Task DeleteAsync(int usuarioId)
        {
            var query = "DELETE FROM usuarios WHERE usuario_id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = usuarioId });
        }
    }
}
