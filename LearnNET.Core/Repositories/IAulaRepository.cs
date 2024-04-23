using LearnNET.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Repositories
{
    public interface IAulaRepository
    {
        Task<IEnumerable<Aula>> ObterTodas();
        Task<Aula> ObterPorId(int id);  
        Task Adicionar(Aula aula);
        Task Atualizar(Aula aula);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
