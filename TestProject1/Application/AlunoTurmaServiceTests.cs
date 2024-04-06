using ApplicationProjetoBack.Services;
using Dapper;
using DomainProjetoBack.Entities;
using DomainProjetoBack.Interfaces;
using Moq;
using TesteProjetoBack.Infrastructure.Data;

namespace TesteProjetoBack.Repository
{
    public class AlunoTurmaServiceTests
    {
        [Fact]
        public async Task GetAllAlunoTurmas_ReturnsAllAlunoTurmas()
        {

            var expectedAlunoTurmas = new List<AlunoTurma>
            {
                new AlunoTurma { IdAluno = 1, IdTurma = 1 },
                new AlunoTurma { IdAluno = 2, IdTurma = 2 }
            };

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            alunoTurmaRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedAlunoTurmas);

            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            var result = await alunoTurmaService.GetAllAlunoTurmas();

            Assert.NotNull(result);
            Assert.Equal(expectedAlunoTurmas, result);
        }

        [Fact]
        public async Task GetAlunoTurmaById_ReturnsAlunoTurmaWithGivenIds()
        {
            var expectedAlunoTurma = new AlunoTurma { IdAluno = 1, IdTurma = 1 };

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            alunoTurmaRepositoryMock.Setup(repo => repo.GetById(1, 1)).ReturnsAsync(expectedAlunoTurma);

            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            var result = await alunoTurmaService.GetAlunoTurmaById(1, 1);


            Assert.NotNull(result);
            Assert.Equal(expectedAlunoTurma, result);
        }

        [Fact]
        public async Task AddAlunoTurma_AddsNewAlunoTurma()
        {
            var newAlunoTurma = new AlunoTurma { IdAluno = 3, IdTurma = 3 };

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            await alunoTurmaService.AddAlunoTurma(newAlunoTurma);

            alunoTurmaRepositoryMock.Verify(repo => repo.Add(newAlunoTurma), Times.Once);
        }

        [Fact]
        public async Task UpdateAlunoTurma_UpdatesExistingAlunoTurma()
        {
            var existingAlunoTurma = new AlunoTurma { IdAluno = 1, IdTurma = 1 };

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            await alunoTurmaService.UpdateAlunoTurma(existingAlunoTurma);

            alunoTurmaRepositoryMock.Verify(repo => repo.Update(existingAlunoTurma), Times.Once);
        }

        [Fact]
        public async Task DeleteAlunoTurma_RemovesAlunoTurmaWithGivenIds()
        {
            var idTurma = 1;
            var idAluno = 1;

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            await alunoTurmaService.DeleteAlunoTurma(idTurma, idAluno);

            alunoTurmaRepositoryMock.Verify(repo => repo.Delete(idTurma, idAluno), Times.Once);
        }

        [Fact]
        public async Task GetAlunosDisponiveis_ReturnsAlunosNotInTurma()
        {
            var expectedAlunos = new List<Aluno>
            {
                new Aluno { Id = 3, Nome = "Carlos" },
                new Aluno { Id = 4, Nome = "Ana" }
            };

            var idTurma = 1;

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            alunoTurmaRepositoryMock.Setup(repo => repo.GetAlunosDisponiveis(idTurma)).ReturnsAsync(expectedAlunos);

            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            var result = await alunoTurmaService.GetAlunosDisponiveis(idTurma);

            Assert.NotNull(result);
            Assert.Equal(expectedAlunos, result);
        }

        [Fact]
        public async Task GetTurmasDisponiveis_ReturnsTurmasNotInAluno()
        {
            var expectedTurmas = new List<Turma>
            {
                new Turma { Id = 3, Nome = "Turma 3" },
                new Turma { Id = 4, Nome = "Turma 4" }
            };

            var idAluno = 1;

            var alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            alunoTurmaRepositoryMock.Setup(repo => repo.GetTurmasDisponiveis(idAluno)).ReturnsAsync(expectedTurmas);

            var alunoTurmaService = new AlunoTurmaService(alunoTurmaRepositoryMock.Object);

            var result = await alunoTurmaService.GetTurmasDisponiveis(idAluno);

            Assert.NotNull(result);
            Assert.Equal(expectedTurmas, result);
        }
    }
}
