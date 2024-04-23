using LearnNET.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Entities
{
    public class PagamentoAssinatura
    {
        public int Id { get; set; }
        public DateTime DataProcessamento { get; set; }
        public PagamentoAssinaturaStatus Status { get; set; }
        public string Mensagem { get; set; }
        public decimal Valor { get; set; }
        public int IdUsuarioAssinatura { get; set; }
        public string LinkPagamento { get; set; }
        public string IdExternoPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
