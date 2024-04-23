using LearnNET.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Repositories
{
    public interface IAssinaturaRepository
    {
        Task<IEnumerable<Assinatura>> ObterTodas();
        Task<Assinatura> ObterPorId(int id);
        Task Adicionar(Assinatura assinatura);
        Task Atualizar(Assinatura assinatura);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
