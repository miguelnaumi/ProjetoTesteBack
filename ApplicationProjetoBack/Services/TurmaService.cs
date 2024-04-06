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
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<IEnumerable<Turma>> GetAllTurmas()
        {
            return await _turmaRepository.GetAll();
        }

        public async Task<Turma> GetTurmaById(int id)
        {
            return await _turmaRepository.GetById(id);
        }

        public async Task AddTurma(Turma turma)
        {
            await _turmaRepository.Add(turma);
        }

        public async Task UpdateTurma(Turma turma)
        {
            await _turmaRepository.Update(turma);
        }

        public async Task DeleteTurma(int id)
        {
            await _turmaRepository.Delete(id);
        }
    }
}
