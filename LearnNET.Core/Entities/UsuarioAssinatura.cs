using LearnNET.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Entities
{
    public class UsuarioAssinatura
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdAssinatura { get; set; }
        public UsuarioAssinaturaStatus Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
