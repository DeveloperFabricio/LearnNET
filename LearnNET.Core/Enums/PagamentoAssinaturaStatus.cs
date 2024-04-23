using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Enums
{
    public enum PagamentoAssinaturaStatus
    {
        [Description("Sucesso")]
        Sucesso = 1,
        [Description("Falha")]
        Falha = 2,
        [Description("Pendente")]
        Pendente = 3,
        [Description("Atrasado")]
        Atrasado = 4
    }
}
