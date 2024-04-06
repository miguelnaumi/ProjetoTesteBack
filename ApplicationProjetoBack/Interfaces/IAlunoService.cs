using DomainProjetoBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProjetoBack.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAllAlunos();
        Task<Aluno> GetAlunoById(int id);
        Task AddAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(int id);
        Task<IEnumerable<Aluno>> GetAlunosByIdTurma(int id);
    }
}
