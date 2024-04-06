using Microsoft.AspNetCore.Mvc;
using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ServiceProjetoBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : BaseController
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
        {
            return await ResolveResponse(_cursoService.GetAllCursos(), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            return await ResolveResponse(_cursoService.GetCursoById(id), EnumeratorsCommons.DataOperation.Select);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Curso curso)
        {
            return await ResolveResponse(_cursoService.AddCurso(curso), EnumeratorsCommons.DataOperation.Insert);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }
            return await ResolveResponse(_cursoService.UpdateCurso(curso), EnumeratorsCommons.DataOperation.Update);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await ResolveResponse(_cursoService.DeleteCurso(id), EnumeratorsCommons.DataOperation.Delete);
        }
    }
}
