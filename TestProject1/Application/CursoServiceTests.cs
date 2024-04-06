using ApplicationProjetoBack.Services;
using Dapper;
using DomainProjetoBack.Entities;
using DomainProjetoBack.Interfaces;
using Moq;
using TesteProjetoBack.Infrastructure.Data;
using Xunit;

namespace TesteProjetoBack.Repository
{
    public class CursoServiceTests
    {
        [Fact]
        public async Task GetAllCursos_ReturnsAllCursos()
        {
            var expectedCursos = new List<Curso>
            {
                new Curso { Id = 1, Nome = "Curso 1", DuracaoSemestre = 2 },
                new Curso { Id = 2, Nome = "Curso 2", DuracaoSemestre = 3 }
            };

            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedCursos);

            var cursoService = new CursoService(cursoRepositoryMock.Object);

            var result = await cursoService.GetAllCursos();

            Assert.NotNull(result);
            Assert.Equal(expectedCursos, result);
        }

        [Fact]
        public async Task GetCursoById_ReturnsCursoWithGivenId()
        {
            var expectedCurso = new Curso { Id = 1, Nome = "Curso 1", DuracaoSemestre = 2 };

            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(repo => repo.GetById(1)).ReturnsAsync(expectedCurso);

            var cursoService = new CursoService(cursoRepositoryMock.Object);

            var result = await cursoService.GetCursoById(1);

            Assert.NotNull(result);
            Assert.Equal(expectedCurso, result);
        }

        [Fact]
        public async Task AddCurso_AddsNewCurso()
        {
            var newCurso = new Curso { Nome = "Curso Novo", DuracaoSemestre = 4 };

            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var cursoService = new CursoService(cursoRepositoryMock.Object);

            await cursoService.AddCurso(newCurso);

            cursoRepositoryMock.Verify(repo => repo.Add(newCurso), Times.Once);
        }

        [Fact]
        public async Task UpdateCurso_UpdatesExistingCurso()
        {
            var existingCurso = new Curso { Id = 1, Nome = "Curso 1", DuracaoSemestre = 2 };

            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var cursoService = new CursoService(cursoRepositoryMock.Object);

            await cursoService.UpdateCurso(existingCurso);

            cursoRepositoryMock.Verify(repo => repo.Update(existingCurso), Times.Once);
        }

        [Fact]
        public async Task DeleteCurso_RemovesCursoWithGivenId()
        {
            var cursoId = 1;

            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var cursoService = new CursoService(cursoRepositoryMock.Object);

            await cursoService.DeleteCurso(cursoId);

            cursoRepositoryMock.Verify(repo => repo.Delete(cursoId), Times.Once);
        }
    }
}
