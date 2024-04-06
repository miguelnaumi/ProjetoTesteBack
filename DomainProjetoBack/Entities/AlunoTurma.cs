namespace DomainProjetoBack.Entities
{
    public class AlunoTurma
    {
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public string? AlunoNome { get; set; }
        public string? TurmaNome { get; set; }
        public int? IdAlunoOld { get; set; }
        public int? IdTurmaOld { get; set; }
    }
}

