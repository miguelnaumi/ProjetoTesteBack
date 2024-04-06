using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DomainProjetoBack.Entities;
using DomainProjetoBack.Interfaces;

namespace TesteProjetoBack.Infrastructure.Data
{
    public class CursoRepository : ICursoRepository
    {
        private readonly IDbConnection _dbConnection;

        public CursoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Curso>> GetAll()
        {
            string query = "SELECT * FROM Curso";
            return await _dbConnection.QueryAsync<Curso>(query);
        }

        public async Task<Curso> GetById(int id)
        {
            string query = "SELECT * FROM Curso WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Curso>(query, new { Id = id });
        }

        public async Task Add(Curso curso)
        {
            string query = "INSERT INTO Curso (Nome, DuracaoSemestre) VALUES (@Nome, @DuracaoSemestre)";
            await _dbConnection.ExecuteAsync(query, curso);
        }

        public async Task Update(Curso curso)
        {
            string query = "UPDATE Curso SET Nome = @Nome, DuracaoSemestre = @DuracaoSemestre WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, curso);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Curso WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
