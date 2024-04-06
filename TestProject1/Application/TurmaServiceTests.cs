using ApplicationProjetoBack.Services;
using Dapper;
using DomainProjetoBack.Entities;
using DomainProjetoBack.Interfaces;
using Moq;
using TesteProjetoBack.Infrastructure.Data;

namespace TesteProjetoBack.Repository
{
    public class TurmaServiceTests
    {
        [Fact]
        public async Task GetAllTurmas_ReturnsAllTurmas()
        {
            var expectedTurmas = new List<Turma>
            {
                new Turma { Id = 1, IdCurso = 1, Nome = "Turma 1", Ano = 2023 },
                new Turma { Id = 2, IdCurso = 2, Nome = "Turma 2", Ano = 2024 }
            };

            var turmaRepositoryMock = new Mock<ITurmaRepository>();
            turmaRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedTurmas);

            var turmaService = new TurmaService(turmaRepositoryMock.Object);

            var result = await turmaService.GetAllTurmas();

            Assert.NotNull(result);
            Assert.Equal(expectedTurmas, result);
        }

        [Fact]
        public async Task GetTurmaById_ReturnsTurmaWithGivenId()
        {
            var expectedTurma = new Turma { Id = 1, IdCurso = 1, Nome = "Turma 1", Ano = 2023 };

            var turmaRepositoryMock = new Mock<ITurmaRepository>();
            turmaRepositoryMock.Setup(repo => repo.GetById(1)).ReturnsAsync(expectedTurma);

            var turmaService = new TurmaService(turmaRepositoryMock.Object);

            var result = await turmaService.GetTurmaById(1);

            Assert.NotNull(result);
            Assert.Equal(expectedTurma, result);
        }

        [Fact]
        public async Task AddTurma_AddsNewTurma()
        {
            var newTurma = new Turma { IdCurso = 1, Nome = "Nova Turma", Ano = 2025 };

            var turmaRepositoryMock = new Mock<ITurmaRepository>();
            var turmaService = new TurmaService(turmaRepositoryMock.Object);

            await turmaService.AddTurma(newTurma);

            turmaRepositoryMock.Verify(repo => repo.Add(newTurma), Times.Once);
        }

        [Fact]
        public async Task UpdateTurma_UpdatesExistingTurma()
        {
            var existingTurma = new Turma { Id = 1, IdCurso = 1, Nome = "Turma 1", Ano = 2023 };

            var turmaRepositoryMock = new Mock<ITurmaRepository>();
            var turmaService = new TurmaService(turmaRepositoryMock.Object);

            await turmaService.UpdateTurma(existingTurma);

            turmaRepositoryMock.Verify(repo => repo.Update(existingTurma), Times.Once);
        }

        [Fact]
        public async Task DeleteTurma_RemovesTurmaWithGivenId()
        {
            var turmaId = 1;

            var turmaRepositoryMock = new Mock<ITurmaRepository>();
            var turmaService = new TurmaService(turmaRepositoryMock.Object);

            await turmaService.DeleteTurma(turmaId);

            turmaRepositoryMock.Verify(repo => repo.Delete(turmaId), Times.Once);
        }
    }
}
