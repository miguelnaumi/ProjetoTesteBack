using Microsoft.AspNetCore.Mvc;
using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationProjetoBack.Services;

namespace ServiceProjetoBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : BaseController
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAll()
        {
            return await ResolveResponse(_alunoService.GetAllAlunos(), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetById(int id)
        {
            return await ResolveResponse(_alunoService.GetAlunoById(id), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Aluno aluno)
        {
            return await ResolveResponse(_alunoService.AddAluno(aluno), EnumeratorsCommons.DataOperation.Insert);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return BadRequest();
            }
            return await ResolveResponse(_alunoService.UpdateAluno(aluno), EnumeratorsCommons.DataOperation.Update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await _alunoService.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return await ResolveResponse(_alunoService.DeleteAluno(id), EnumeratorsCommons.DataOperation.Delete);
        }

        [HttpGet("turma/{id}")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosByIdTurma(int id)
        {
            return await ResolveResponse(_alunoService.GetAlunosByIdTurma(id), EnumeratorsCommons.DataOperation.Select);
        }
    }
}
