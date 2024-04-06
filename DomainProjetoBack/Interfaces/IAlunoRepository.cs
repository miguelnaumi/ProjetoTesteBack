using DomainProjetoBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProjetoBack.Interfaces
{
    public interface IAlunoRepository
    {
        Task Add(Aluno aluno);
        Task Delete(int id);
        Task<IEnumerable<Aluno>> GetAll();
        Task<IEnumerable<Aluno>> GetAlunosByIdTurma(int idTurma);
        Task<Aluno> GetById(int id);
        Task Update(Aluno aluno);
    }
}
