using Dapper;
using DomainProjetoBack.Entities;
using System.Data;

namespace TesteProjetoBack.Infrastructure.Data
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly IDbConnection _dbConnection;

        public TurmaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Turma>> GetAll()
        {
            string query = "SELECT Turma.*,Curso.Nome AS CursoNome,CASE WHEN EXISTS (SELECT 1 FROM AlunoTurma WHERE AlunoTurma.IdTurma = Turma.Id)" +
                "THEN 1 ELSE 0 END AS AlunosVinculados FROM Turma INNER JOIN Curso ON Curso.Id = Turma.IdCurso;";
            return await _dbConnection.QueryAsync<Turma>(query);
        }

        public async Task<Turma> GetById(int id)
        {
            string query = "SELECT * FROM Turma WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Turma>(query, new { Id = id });
        }

        public async Task Add(Turma turma)
        {
            string query = "INSERT INTO Turma (IdCurso, Nome, Ano) VALUES (@IdCurso, @Nome, @Ano)";
            await _dbConnection.ExecuteAsync(query, turma);
        }

        public async Task Update(Turma turma)
        {
            string query = "UPDATE Turma SET IdCurso = @IdCurso, Nome = @Nome, Ano = @Ano WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, turma);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Turma WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
