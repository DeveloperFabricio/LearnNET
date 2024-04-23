using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Enums
{
    public enum UsuarioAssinaturaStatus
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Ativo")]
        Ativo = 2,
        [Description("Desativado")]
        Desativado = 3,
        [Description("Expirado")]
        Expirado = 4
    }
}
