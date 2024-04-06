using DomainProjetoBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProjetoBack.Interfaces
{
    public interface ICursoRepository
    {
        Task Add(Curso curso);
        Task Delete(int id);
        Task<IEnumerable<Curso>> GetAll();
        Task<Curso> GetById(int id);
        Task Update(Curso curso);
    }
}
