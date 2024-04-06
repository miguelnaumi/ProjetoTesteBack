using DomainProjetoBack.Entities;

namespace ApplicationProjetoBack.Interfaces
{
    public interface IAlunoTurmaService
    {
        Task AddAlunoTurma(AlunoTurma alunoTurma);
        Task DeleteAlunoTurma(int idTurma, int idAluno);
        Task<IEnumerable<AlunoTurma>> GetAllAlunoTurmas();
        Task<IEnumerable<Aluno>> GetAlunosDisponiveis(int idTurma);
        Task<AlunoTurma> GetAlunoTurmaById(int idTurma, int idAluno);
        Task<IEnumerable<Turma>> GetTurmasDisponiveis(int idAluno);
        Task UpdateAlunoTurma(AlunoTurma alunoTurma);
    }
}