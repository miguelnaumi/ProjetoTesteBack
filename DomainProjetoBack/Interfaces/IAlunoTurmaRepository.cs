using DomainProjetoBack.Entities;

namespace TesteProjetoBack.Infrastructure.Data
{
    public interface IAlunoTurmaRepository
    {
        Task Add(AlunoTurma alunoTurma);
        Task Delete(int idTurma, int idAluno);
        Task<IEnumerable<AlunoTurma>> GetAll();
        Task<IEnumerable<Aluno>> GetAlunosDisponiveis(int idTurma);
        Task<AlunoTurma> GetById(int idTurma, int idAluno);
        Task<IEnumerable<Turma>> GetTurmasDisponiveis(int idAluno);
        Task Update(AlunoTurma alunoTurma);
    }
}