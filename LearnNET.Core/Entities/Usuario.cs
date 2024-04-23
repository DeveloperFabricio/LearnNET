using LearnNET.Core.Enums;

namespace LearnNET.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }
        public PapelEnum Papel { get; set; }
        public bool Ativo { get; set; }

        public int? AssinaturaId { get; set; }
        public Assinatura Assinatura { get; set; }

        public void Delete()
        {
            Ativo = false;
        }
    }
}
