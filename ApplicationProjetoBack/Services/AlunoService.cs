using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProjetoBack.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<Aluno>> GetAllAlunos()
        {
            return await _alunoRepository.GetAll();
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            return await _alunoRepository.GetById(id);
        }

        public async Task AddAluno(Aluno aluno)
        {
            await _alunoRepository.Add(aluno);
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            await _alunoRepository.Update(aluno);
        }

        public async Task DeleteAluno(int id)
        {
            await _alunoRepository.Delete(id);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByIdTurma(int id)
        {
            return await _alunoRepository.GetAlunosByIdTurma(id);
        }
    }
}
