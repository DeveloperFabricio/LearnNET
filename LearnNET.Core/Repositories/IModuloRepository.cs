using LearnNET.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Repositories
{
    public interface IModuloRepository
    {
        Task<IEnumerable<Modulo>> ObterTodos();
        Task<Modulo> ObterPorId(int id);
        Task Adicionar(Modulo modulo);
        Task Atualizar(Modulo modulo);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
