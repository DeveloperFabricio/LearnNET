namespace LearnNET.Core.Entities
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Aula> Aulas { get; set; }
       
    }
}
