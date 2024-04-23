namespace LearnNET.Application.DTO_s
{
    public class ModuloDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public CursoDTO Curso { get; set; }
    }
}
