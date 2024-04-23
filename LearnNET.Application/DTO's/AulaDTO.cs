namespace LearnNET.Application.DTO_s
{
    public class AulaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LinkVideo { get; set; }
        public int Duracao { get; set; }
        public ModuloDTO Modulo { get; set; }
    }
}
