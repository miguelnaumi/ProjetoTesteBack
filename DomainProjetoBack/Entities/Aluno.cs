namespace DomainProjetoBack.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdTurma { get; set; }
        public string? Turma { get; set; }
        public int Semestre { get; set; } = 1;
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
