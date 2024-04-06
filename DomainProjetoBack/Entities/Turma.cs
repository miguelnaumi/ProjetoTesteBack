namespace DomainProjetoBack.Entities
{
    public class Turma
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string? CursoNome { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool AlunosVinculados { get; set; }
    }

}
