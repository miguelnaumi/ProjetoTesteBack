using DomainProjetoBack.Entities;

namespace TesteProjetoBack.Infrastructure.Data
{
    public interface ITurmaRepository
    {
        Task Add(Turma turma);
        Task Delete(int id);
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> GetById(int id);
        Task Update(Turma turma);
    }
}