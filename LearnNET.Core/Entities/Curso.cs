namespace LearnNET.Core.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Modulo> Modulos { get; set; }
    }
}
