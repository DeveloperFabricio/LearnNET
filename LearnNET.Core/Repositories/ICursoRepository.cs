using LearnNET.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Repositories
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> ObterTodos();
        Task<Curso> ObterPorId(int id);
        Task Adicionar(Curso curso);
        Task Atualizar(Curso curso);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
