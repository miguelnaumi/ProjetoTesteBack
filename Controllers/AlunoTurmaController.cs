using Microsoft.AspNetCore.Mvc;
using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ApplicationProjetoBack.Services;

namespace ServiceProjetoBack.Controllers
{
    [ApiController]
    [Route("api/alunoturma")]
    public class AlunoTurmaController : BaseController
    {
        private readonly IAlunoTurmaService _alunoturmaService;

        public AlunoTurmaController(IAlunoTurmaService alunoturmaService)
        {
            _alunoturmaService = alunoturmaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoTurma>>> GetAll()
        {
            return await ResolveResponse(_alunoturmaService.GetAllAlunoTurmas(), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpGet("{idTurma}/{idAluno}")]
        public async Task<ActionResult<AlunoTurma>> GetById(int idTurma, int idAluno)
        {
            return await ResolveResponse(_alunoturmaService.GetAlunoTurmaById(idTurma, idAluno), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AlunoTurma alunoTurma)
        {
            return await ResolveResponse(_alunoturmaService.AddAlunoTurma(alunoTurma), EnumeratorsCommons.DataOperation.Insert);
        }

        [HttpPut("{idTurma}/{idAluno}")]
        public async Task<ActionResult> Update(int idTurma, int idAluno, AlunoTurma alunoTurma)
        {
            if (idTurma != alunoTurma.IdTurma && idAluno != alunoTurma.IdAluno)
            {
                return BadRequest();
            }
            return await ResolveResponse(_alunoturmaService.UpdateAlunoTurma(alunoTurma), EnumeratorsCommons.DataOperation.Update);
        }

        [HttpDelete("{idTurma}/{idAluno}")]
        public async Task<ActionResult> Delete(int idTurma, int idAluno)
        {
            var alunoturma = await _alunoturmaService.GetAlunoTurmaById(idTurma, idAluno);
            if (alunoturma == null)
            {
                return NotFound();
            }
            return await ResolveResponse(_alunoturmaService.DeleteAlunoTurma(idTurma, idAluno), EnumeratorsCommons.DataOperation.Delete);
        }

        [HttpGet("turmas/{idAluno}")]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmasDisponiveis(int idAluno)
        {
            return await ResolveResponse(_alunoturmaService.GetTurmasDisponiveis(idAluno), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpGet("alunos/{idTurma}")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosDisponiveis(int idTurma)
        {
            return await ResolveResponse(_alunoturmaService.GetAlunosDisponiveis(idTurma), EnumeratorsCommons.DataOperation.Select);
        }
    }
}
