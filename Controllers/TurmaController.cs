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
    [Route("api/[controller]")]
    public class TurmaController : BaseController
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetAll()
        {
            return await ResolveResponse(_turmaService.GetAllTurmas(), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetById(int id)
        {
            return await ResolveResponse(_turmaService.GetTurmaById(id), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Turma turma)
        {
            return await ResolveResponse(_turmaService.AddTurma(turma), EnumeratorsCommons.DataOperation.Insert);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Turma turma)
        {
            if (id != turma.Id)
            {
                return BadRequest();
            }
            return await ResolveResponse(_turmaService.UpdateTurma(turma), EnumeratorsCommons.DataOperation.Update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turma = await _turmaService.GetTurmaById(id);
            if (turma == null)
            {
                return NotFound();
            }
            return await ResolveResponse(_turmaService.DeleteTurma(id), EnumeratorsCommons.DataOperation.Delete);
        }
    }
}
