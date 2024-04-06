using ApplicationProjetoBack.Interfaces;
using DomainProjetoBack.Interfaces;
using DomainProjetoBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteProjetoBack.Infrastructure.Data;

namespace ApplicationProjetoBack.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoturmaRepository;

        public AlunoTurmaService(IAlunoTurmaRepository alunoturmaRepository)
        {
            _alunoturmaRepository = alunoturmaRepository;
        }

        public async Task<IEnumerable<AlunoTurma>> GetAllAlunoTurmas()
        {
            return await _alunoturmaRepository.GetAll();
        }

        public async Task<AlunoTurma> GetAlunoTurmaById(int idTurma, int idAluno)
        {
            return await _alunoturmaRepository.GetById(idTurma, idAluno);
        }

        public async Task AddAlunoTurma(AlunoTurma alunoTurma)
        {
            await _alunoturmaRepository.Add(alunoTurma);
        }

        public async Task UpdateAlunoTurma(AlunoTurma alunoTurma)
        {
            await _alunoturmaRepository.Update(alunoTurma);
        }

        public async Task DeleteAlunoTurma(int idTurma, int idAluno)
        {
            await _alunoturmaRepository.Delete(idTurma, idAluno);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosDisponiveis(int idTurma)
        {
            return await _alunoturmaRepository.GetAlunosDisponiveis(idTurma);
        }

        public async Task<IEnumerable<Turma>> GetTurmasDisponiveis(int idAluno)
        {
            return await _alunoturmaRepository.GetTurmasDisponiveis(idAluno);
        }
    }
}
