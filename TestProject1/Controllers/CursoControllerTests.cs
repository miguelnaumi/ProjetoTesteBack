using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceProjetoBack.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteProjetoBack.Controllers
{
    public class CursoControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllCursos()
        {
            var expectedCursos = new List<Curso>
        {
            new Curso { Id = 1, Nome = "Curso A" },
            new Curso { Id = 2, Nome = "Curso B" }
        };

            var cursoServiceMock = new Mock<ICursoService>();
            cursoServiceMock.Setup(service => service.GetAllCursos()).ReturnsAsync(expectedCursos);

            var controller = new CursoController(cursoServiceMock.Object);

            var result = await controller.GetAll();

            Assert.IsType<ActionResult<IEnumerable<Curso>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<Curso>>(valueResult);
            Assert.Equal(expectedCursos, model);
        }

        [Fact]
        public async Task GetById_ReturnsCursoWithGivenId()
        {
            var expectedCurso = new Curso { Id = 1, Nome = "Curso A" };

            var cursoServiceMock = new Mock<ICursoService>();
            cursoServiceMock.Setup(service => service.GetCursoById(1)).ReturnsAsync(expectedCurso);

            var controller = new CursoController(cursoServiceMock.Object);

            var result = await controller.GetById(1);

            Assert.IsType<ActionResult<Curso>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsType<Curso>(valueResult);
            Assert.Equal(expectedCurso, model);
        }

        [Fact]
        public async Task Add_AddsNewCurso()
        {
            var newCurso = new Curso { Nome = "Novo Curso" };

            var cursoServiceMock = new Mock<ICursoService>();
            cursoServiceMock.Setup(service => service.AddCurso(newCurso));

            var controller = new CursoController(cursoServiceMock.Object);

            var result = await controller.Add(newCurso);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Update_UpdatesExistingCurso()
        {
            var existingCurso = new Curso { Id = 1, Nome = "Curso A" };

            var cursoServiceMock = new Mock<ICursoService>();
            cursoServiceMock.Setup(service => service.UpdateCurso(existingCurso));

            var controller = new CursoController(cursoServiceMock.Object);

            var result = await controller.Update(1, existingCurso);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_RemovesCursoWithGivenId()
        {
            var cursoId = 1;

            var cursoServiceMock = new Mock<ICursoService>();
            cursoServiceMock.Setup(service => service.DeleteCurso(cursoId));

            var controller = new CursoController(cursoServiceMock.Object);

            var result = await controller.Delete(cursoId);

            Assert.IsType<OkObjectResult>(result);
        }
    }

}
