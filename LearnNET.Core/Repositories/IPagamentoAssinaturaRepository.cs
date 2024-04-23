using LearnNET.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Repositories
{
    public interface IPagamentoAssinaturaRepository
    {
        Task<IEnumerable<PagamentoAssinatura>> ObterTodos();
        Task<PagamentoAssinatura> ObterPorId(int id);
        Task Adicionar(PagamentoAssinatura pagamentoAssinatura);
        Task Atualizar(PagamentoAssinatura pagamentoAssinatura);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
