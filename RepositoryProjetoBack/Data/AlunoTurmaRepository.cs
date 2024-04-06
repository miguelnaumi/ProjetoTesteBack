using Dapper;
using DomainProjetoBack.Entities;
using System.Data;

namespace TesteProjetoBack.Infrastructure.Data
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly IDbConnection _dbConnection;

        public AlunoTurmaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<AlunoTurma>> GetAll()
        {
            string query = "SELECT alt.*,a.Nome AS AlunoNome,t.Nome AS TurmaNome FROM AlunoTurma alt " +
                "INNER JOIN Aluno a ON alt.IdAluno = a.Id " +
                "INNER JOIN Turma t ON alt.IdTurma = t.Id";
            return await _dbConnection.QueryAsync<AlunoTurma>(query);
        }

        public async Task<AlunoTurma> GetById(int idTurma, int idAluno)
        {
            string query = "SELECT alt.*,a.Nome AS AlunoNome,t.Nome AS TurmaNome FROM AlunoTurma alt " +
                "INNER JOIN Aluno a ON alt.IdAluno = a.Id " +
                "INNER JOIN Turma t ON alt.IdTurma = t.Id WHERE idAluno = @IdAluno AND IdTurma = @IdTurma";
            return await _dbConnection.QueryFirstOrDefaultAsync<AlunoTurma>(query, new { IdTurma = idTurma, IdAluno = idAluno });
        }

        public async Task Add(AlunoTurma alunoTurma)
        {
            string query = "INSERT INTO AlunoTurma (IdTurma, IdAluno) VALUES (@IdTurma, @IdAluno)";
            await _dbConnection.ExecuteAsync(query, alunoTurma);
        }

        public async Task Update(AlunoTurma alunoTurma)
        {
            string query = "UPDATE AlunoTurma SET IdTurma = @IdTurma, IdAluno = @IdAluno WHERE IdTurma = @IdTurmaOld AND IdAluno = @IdAlunoOld ";
            await _dbConnection.ExecuteAsync(query, alunoTurma);
        }

        public async Task Delete(int idTurma, int idAluno)
        {
            string query = "DELETE FROM AlunoTurma WHERE IdTurma = @IdTurma AND IdAluno = @IdAluno";
            await _dbConnection.ExecuteAsync(query, new { IdTurma = idTurma, IdAluno = idAluno });
        }

        public async Task<IEnumerable<Aluno>> GetAlunosDisponiveis(int idTurma)
        {
            string query = "SELECT * FROM Aluno ";
            if(idTurma > 0)
                query += "WHERE Id NOT IN (SELECT IdAluno FROM AlunoTurma WHERE IdTurma = @IdTurma)";
            return await _dbConnection.QueryAsync<Aluno>(query, new { IdTurma = idTurma });
        }

        public async Task<IEnumerable<Turma>> GetTurmasDisponiveis(int idAluno)
        {
            string query = "SELECT * FROM Turma ";
            if(idAluno > 0)
                query += "WHERE Id NOT IN (SELECT IdTurma FROM AlunoTurma WHERE IdAluno = @IdAluno)";
            return await _dbConnection.QueryAsync<Turma>(query, new { IdAluno = idAluno } );
        }
    }
}
