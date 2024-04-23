namespace LearnNET.Core.Entities
{
    public class UsuarioAulaConcluida
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdAula { get; set; }
        public DateTime DataConclusao { get; set; }
        public int Nota { get; set; }

        public Usuario Usuario { get; set; }
        public Aula Aula { get; set; }
    }
}
