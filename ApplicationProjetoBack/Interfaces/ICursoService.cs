using DomainProjetoBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProjetoBack.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllCursos();
        Task<Curso> GetCursoById(int id);
        Task AddCurso(Curso curso);
        Task UpdateCurso(Curso curso);
        Task DeleteCurso(int id);
    }
}
