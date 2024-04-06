using ApplicationProjetoBack.Services;
using Dapper;
using DomainProjetoBack.Entities;
using DomainProjetoBack.Interfaces;
using Moq;
using TesteProjetoBack.Infrastructure.Data;

namespace TesteProjetoBack.Repository
{
    public class AlunoServiceTests
    {
        [Fact]
        public async Task GetAllAlunos_ReturnsAllAlunos()
        {
            var expectedAlunos = new List<Aluno>
            {
                new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" },
                new Aluno { Id = 2, Nome = "Maria", Semestre = 3, Usuario = "maria456", Senha = "senha456" }
            };

            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            alunoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedAlunos);

            var alunoService = new AlunoService(alunoRepositoryMock.Object);

            var result = await alunoService.GetAllAlunos();

            Assert.NotNull(result);
            Assert.Equal(expectedAlunos, result);
        }

        [Fact]
        public async Task GetAlunoById_ReturnsAlunoWithGivenId()
        {
            var expectedAluno = new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" };

            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            alunoRepositoryMock.Setup(repo => repo.GetById(1)).ReturnsAsync(expectedAluno);

            var alunoService = new AlunoService(alunoRepositoryMock.Object);

            var result = await alunoService.GetAlunoById(1);

            Assert.NotNull(result);
            Assert.Equal(expectedAluno, result);
        }

        [Fact]
        public async Task AddAluno_AddsNewAluno()
        {
            var newAluno = new Aluno { Nome = "José", Semestre = 1, Usuario = "jose789", Senha = "senha789" };

            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            var alunoService = new AlunoService(alunoRepositoryMock.Object);

            await alunoService.AddAluno(newAluno);

            alunoRepositoryMock.Verify(repo => repo.Add(newAluno), Times.Once);
        }

        [Fact]
        public async Task UpdateAluno_UpdatesExistingAluno()
        {
            var existingAluno = new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" };

            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            var alunoService = new AlunoService(alunoRepositoryMock.Object);

            await alunoService.UpdateAluno(existingAluno);

            alunoRepositoryMock.Verify(repo => repo.Update(existingAluno), Times.Once);
        }

        [Fact]
        public async Task DeleteAluno_RemovesAlunoWithGivenId()
        {
            var alunoId = 1;

            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            var alunoService = new AlunoService(alunoRepositoryMock.Object);

            await alunoService.DeleteAluno(alunoId);

            alunoRepositoryMock.Verify(repo => repo.Delete(alunoId), Times.Once);
        }

        [Fact]
        public async Task GetAlunosByIdTurma_ReturnsAlunosForGivenTurmaId()
        {
            var expectedAlunos = new List<Aluno>
            {
                new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" },
                new Aluno { Id = 2, Nome = "Maria", Semestre = 3, Usuario = "maria456", Senha = "senha456" }
            };

            var turmaId = 1;

            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            alunoRepositoryMock.Setup(repo => repo.GetAlunosByIdTurma(turmaId)).ReturnsAsync(expectedAlunos);

            var alunoService = new AlunoService(alunoRepositoryMock.Object);

            var result = await alunoService.GetAlunosByIdTurma(turmaId);

            Assert.NotNull(result);
            Assert.Equal(expectedAlunos, result);
        }
    }
}
