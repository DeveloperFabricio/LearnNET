namespace LearnNET.Core.Entities
{
    public class Assinatura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public List<Curso> Cursos { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
