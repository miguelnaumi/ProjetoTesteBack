using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DomainProjetoBack.Entities;
using DomainProjetoBack.Interfaces;

namespace TesteProjetoBack.Infrastructure.Data
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnection _dbConnection;

        public AlunoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            string query = "SELECT * FROM Aluno";
            return await _dbConnection.QueryAsync<Aluno>(query);
        }

        public async Task<Aluno> GetById(int id)
        {
            string query = "SELECT * FROM Aluno WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Aluno>(query, new { Id = id });
        }

        public async Task Add(Aluno aluno)
        {
            string query = "INSERT INTO Aluno (Nome,Semestre, Usuario, Senha) VALUES (@Nome,@Semestre, @Usuario, @Senha)";
            await _dbConnection.ExecuteAsync(query, aluno);
        }

        public async Task Update(Aluno aluno)
        {
            string query = "UPDATE Aluno SET Nome = @Nome, Semestre = @Semestre, Usuario = @Usuario, Senha = @Senha WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, aluno);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Aluno WHERE Id = @Id DELETE FROM AlunoTurma WHERE IdAluno = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByIdTurma(int idTurma)
        {
            string query = "SELECT a.*,t.Nome as Turma, IdTurma FROM Aluno a INNER JOIN AlunoTurma alt ON a.Id = alt.IdAluno INNER JOIN Turma t ON t.Id = alt.IdTurma WHERE IdTurma = @IdTurma";
            return await _dbConnection.QueryAsync<Aluno>(query, new { IdTurma = idTurma });
        }
    }
}
