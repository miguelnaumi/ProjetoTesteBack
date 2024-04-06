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
    public class AlunoTurmaControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllAlunoTurmas()
        {
            var expectedAlunoTurmas = new List<AlunoTurma>
        {
            new AlunoTurma { IdTurma = 1, IdAluno = 1 },
            new AlunoTurma { IdTurma = 2, IdAluno = 2 }
        };

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.GetAllAlunoTurmas()).ReturnsAsync(expectedAlunoTurmas);

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.GetAll();

            Assert.IsType<ActionResult<IEnumerable<AlunoTurma>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<AlunoTurma>>(valueResult);
            Assert.Equal(expectedAlunoTurmas, model);
        }

        [Fact]
        public async Task GetById_ReturnsAlunoTurmaWithGivenIds()
        {
            var expectedAlunoTurma = new AlunoTurma { IdTurma = 1, IdAluno = 1 };

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.GetAlunoTurmaById(1, 1)).ReturnsAsync(expectedAlunoTurma);

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.GetById(1, 1);

            Assert.IsType<ActionResult<AlunoTurma>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsType<AlunoTurma>(valueResult);
            Assert.Equal(expectedAlunoTurma, model);
        }

        [Fact]
        public async Task Add_AddsNewAlunoTurma()
        {
            var newAlunoTurma = new AlunoTurma { IdTurma = 1, IdAluno = 1 };

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.AddAlunoTurma(newAlunoTurma));

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.Add(newAlunoTurma);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Update_UpdatesExistingAlunoTurma()
        {
            var existingAlunoTurma = new AlunoTurma { IdTurma = 1, IdAluno = 1 };

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.UpdateAlunoTurma(existingAlunoTurma));

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.Update(1, 1, existingAlunoTurma);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_RemovesAlunoTurmaWithGivenIds()
        {
            var idTurma = 1;
            var idAluno = 1;

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.DeleteAlunoTurma(idTurma, idAluno)).Returns(Task.CompletedTask);

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.Delete(idTurma, idAluno);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTurmasDisponiveis_ReturnsTurmasForGivenAlunoId()
        {
            var expectedTurmas = new List<Turma>
        {
            new Turma { Id = 1, Nome = "Turma A" },
            new Turma { Id = 2, Nome = "Turma B" }
        };

            var alunoId = 1;

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.GetTurmasDisponiveis(alunoId)).ReturnsAsync(expectedTurmas);

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.GetTurmasDisponiveis(alunoId);

            Assert.IsType<ActionResult<IEnumerable<Turma>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<Turma>>(valueResult);
            Assert.Equal(expectedTurmas, model);
        }

        [Fact]
        public async Task GetAlunosDisponiveis_ReturnsAlunosForGivenTurmaId()
        {
            var expectedAlunos = new List<Aluno>
        {
            new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" },
            new Aluno { Id = 2, Nome = "Maria", Semestre = 3, Usuario = "maria456", Senha = "senha456" }
        };

            var turmaId = 1;

            var alunoturmaServiceMock = new Mock<IAlunoTurmaService>();
            alunoturmaServiceMock.Setup(service => service.GetAlunosDisponiveis(turmaId)).ReturnsAsync(expectedAlunos);

            var controller = new AlunoTurmaController(alunoturmaServiceMock.Object);

            var result = await controller.GetAlunosDisponiveis(turmaId);

            Assert.IsType<ActionResult<IEnumerable<Aluno>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<Aluno>>(valueResult);
            Assert.Equal(expectedAlunos, model);
        }
    }
}
