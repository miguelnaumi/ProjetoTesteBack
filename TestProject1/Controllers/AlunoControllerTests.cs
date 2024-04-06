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
    public class AlunoControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllAlunos()
        {
            var expectedAlunos = new List<Aluno>
            {
                new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" },
                new Aluno { Id = 2, Nome = "Maria", Semestre = 3, Usuario = "maria456", Senha = "senha456" }
            };

            var alunoServiceMock = new Mock<IAlunoService>();
            alunoServiceMock.Setup(service => service.GetAllAlunos()).ReturnsAsync(expectedAlunos);

            var controller = new AlunoController(alunoServiceMock.Object);

            var result = await controller.GetAll();

            Assert.IsType<ActionResult<IEnumerable<Aluno>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<Aluno>>(valueResult);
            Assert.Equal(expectedAlunos, model);
        }

        [Fact]
        public async Task GetById_ReturnsAlunoWithGivenId()
        {
            var expectedAluno = new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" };

            var alunoServiceMock = new Mock<IAlunoService>();
            alunoServiceMock.Setup(service => service.GetAlunoById(1)).ReturnsAsync(expectedAluno);

            var controller = new AlunoController(alunoServiceMock.Object);

            var result = await controller.GetById(1);

            Assert.IsType<ActionResult<Aluno>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsType<Aluno>(valueResult);
            Assert.Equal(expectedAluno, model);
        }

        [Fact]
        public async Task Add_AddsNewAluno()
        {
            var newAluno = new Aluno { Nome = "José", Semestre = 1, Usuario = "jose789", Senha = "senha789" };

            var alunoServiceMock = new Mock<IAlunoService>();
            alunoServiceMock.Setup(service => service.AddAluno(newAluno));

            var controller = new AlunoController(alunoServiceMock.Object);

            var result = await controller.Add(newAluno);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Update_UpdatesExistingAluno()
        {
            var existingAluno = new Aluno { Id = 1, Nome = "João", Semestre = 2, Usuario = "joao123", Senha = "senha123" };

            var alunoServiceMock = new Mock<IAlunoService>();
            alunoServiceMock.Setup(service => service.UpdateAluno(existingAluno));

            var controller = new AlunoController(alunoServiceMock.Object);

            var result = await controller.Update(1, existingAluno);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_RemovesAlunoWithGivenId()
        {
            var alunoId = 1;

            var alunoServiceMock = new Mock<IAlunoService>();
            alunoServiceMock.Setup(service => service.DeleteAluno(alunoId)); 

            var controller = new AlunoController(alunoServiceMock.Object);

            var result = await controller.Delete(alunoId);

            Assert.IsType<OkObjectResult>(result);
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

            var alunoServiceMock = new Mock<IAlunoService>();
            alunoServiceMock.Setup(service => service.GetAlunosByIdTurma(turmaId)).ReturnsAsync(expectedAlunos);

            var controller = new AlunoController(alunoServiceMock.Object);

            var result = await controller.GetAlunosByIdTurma(turmaId);

            Assert.IsType<ActionResult<IEnumerable<Aluno>>>(result);
            var valueResult = result.GetValue().Result;
            var model = Assert.IsAssignableFrom<IEnumerable<Aluno>>(valueResult);
            Assert.Equal(expectedAlunos, model);
        }
    }
}
