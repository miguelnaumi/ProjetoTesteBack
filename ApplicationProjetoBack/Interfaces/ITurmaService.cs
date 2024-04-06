using DomainProjetoBack.Entities;

namespace ApplicationProjetoBack.Interfaces
{
    public interface ITurmaService
    {
        Task AddTurma(Turma turma);
        Task DeleteTurma(int id);
        Task<IEnumerable<Turma>> GetAllTurmas();
        Task<Turma> GetTurmaById(int id);
        Task UpdateTurma(Turma turma);
    }
}