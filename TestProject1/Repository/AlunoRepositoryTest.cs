using Dapper;
using DomainProjetoBack.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteProjetoBack.Infrastructure.Data;

namespace TesteProjetoBack.Repository
{
    public class AlunoRepositoryTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllAlunos()
        {
            // Arrange
            var expectedAlunos = new List<Aluno>
            {
                new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" },
                new Aluno { Id = 2, Nome = "Maria", Semestre = 3, Usuario = "maria456", Senha = "senha456" }
            };

            var dbConnectionMock = new Mock<IDbConnection>();
            dbConnectionMock.Setup(x => x.QueryAsync<Aluno>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>()))
                            .ReturnsAsync(expectedAlunos);

            var repository = new AlunoRepository(dbConnectionMock.Object);

            var result = await repository.GetAll();

            Assert.NotNull(result);
            Assert.Equal(expectedAlunos, result);
        }

        [Fact]
        public async Task GetById_ReturnsAlunoWithGivenId()
        {
            // Arrange
            var expectedAluno = new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" };

            var dbConnectionMock = new Mock<IDbConnection>();
            dbConnectionMock.Setup(x => x.QueryFirstOrDefaultAsync<Aluno>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>()))
                            .ReturnsAsync(expectedAluno);

            var repository = new AlunoRepository(dbConnectionMock.Object);

            // Act
            var result = await repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAluno, result);
        }

        [Fact]
        public async Task Add_AddsNewAluno()
        {
            // Arrange
            var newAluno = new Aluno { Nome = "José", Semestre = 1, Usuario = "jose789", Senha = "senha789" };

            var dbConnectionMock = new Mock<IDbConnection>();
            var repository = new AlunoRepository(dbConnectionMock.Object);

            // Act
            await repository.Add(newAluno);

            // Assert
            dbConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), newAluno, It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>()), Times.Once);
        }

        [Fact]
        public async Task Update_UpdatesExistingAluno()
        {
            // Arrange
            var existingAluno = new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" };

            var dbConnectionMock = new Mock<IDbConnection>();
            var repository = new AlunoRepository(dbConnectionMock.Object);

            // Act
            await repository.Update(existingAluno);

            // Assert
            dbConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), existingAluno, It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>()), Times.Once);
        }

        [Fact]
        public async Task Delete_RemovesAlunoWithGivenId()
        {
            // Arrange
            var alunoId = 1;

            var dbConnectionMock = new Mock<IDbConnection>();
            var repository = new AlunoRepository(dbConnectionMock.Object);

            // Act
            await repository.Delete(alunoId);

            // Assert
            dbConnectionMock.Verify(x => x.ExecuteAsync(It.IsAny<string>(), new { Id = alunoId }, It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>()), Times.Once);
        }

        [Fact]
        public async Task GetAlunosByIdTurma_ReturnsAlunosForGivenTurmaId()
        {
            // Arrange
            var expectedAlunos = new List<Aluno>
            {
                new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" },
                new Aluno { Id = 2, Nome = "Maria", Semestre = 3, Usuario = "maria456", Senha = "senha456" }
            };

            var idTurma = 1;

            var dbConnectionMock = new Mock<IDbConnection>();
            dbConnectionMock.Setup(x => x.QueryAsync<Aluno>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int>(), It.IsAny<CommandType>()))
                            .ReturnsAsync(expectedAlunos);

            var repository = new AlunoRepository(dbConnectionMock.Object);

            // Act
            var result = await repository.GetAlunosByIdTurma(idTurma);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAlunos, result);
        }
    }
}
