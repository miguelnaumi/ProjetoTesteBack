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
    public class TurmaControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllTurmas()
        {
            var expectedTurmas = new List<Turma>
        {
            new Turma { Id = 1, Nome = "Turma A" },
            new Turma { Id = 2, Nome = "Turma B" }
        };

            var turmaServiceMock = new Mock<ITurmaService>();
            turmaServiceMock.Setup(service => service.GetAllTurmas()).ReturnsAsync(expectedTurmas);

            var controller = new TurmaController(turmaServiceMock.Object);

            var result = await controller.GetAll();

            Assert.IsType<ActionResult<IEnumerable<Turma>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<Turma>>(valueResult);
            Assert.Equal(expectedTurmas, model);
        }

        [Fact]
        public async Task GetById_ReturnsTurmaWithGivenId()
        {
            var expectedTurma = new Turma { Id = 1, Nome = "Turma A" };

            var turmaServiceMock = new Mock<ITurmaService>();
            turmaServiceMock.Setup(service => service.GetTurmaById(1)).ReturnsAsync(expectedTurma);

            var controller = new TurmaController(turmaServiceMock.Object);

            var result = await controller.GetById(1);

            Assert.IsType<ActionResult<Turma>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsType<Turma>(valueResult);
            Assert.Equal(expectedTurma, model);
        }

        [Fact]
        public async Task Add_AddsNewTurma()
        {
            var newTurma = new Turma { Nome = "Nova Turma" };

            var turmaServiceMock = new Mock<ITurmaService>();
            turmaServiceMock.Setup(service => service.AddTurma(newTurma));

            var controller = new TurmaController(turmaServiceMock.Object);

            var result = await controller.Add(newTurma);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Update_UpdatesExistingTurma()
        {
            var existingTurma = new Turma { Id = 1, Nome = "Turma A" };

            var turmaServiceMock = new Mock<ITurmaService>();
            turmaServiceMock.Setup(service => service.UpdateTurma(existingTurma));

            var controller = new TurmaController(turmaServiceMock.Object);

            var result = await controller.Update(1, existingTurma);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_RemovesTurmaWithGivenId()
        {
            var turmaId = 1;

            var turmaServiceMock = new Mock<ITurmaService>();
            turmaServiceMock.Setup(service => service.DeleteTurma(turmaId));

            var controller = new TurmaController(turmaServiceMock.Object);

            var result = await controller.Delete(turmaId);

            Assert.IsType<OkObjectResult>(result);
        }
    }

}
