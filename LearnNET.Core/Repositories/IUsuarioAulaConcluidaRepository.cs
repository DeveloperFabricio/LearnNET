using LearnNET.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Repositories
{
    public interface IUsuarioAulaConcluidaRepository
    {
        Task<IEnumerable<UsuarioAulaConcluida>> ObterTodas();
        Task<UsuarioAulaConcluida> ObterPorId(int id);
        Task Adicionar(UsuarioAulaConcluida usuarioAulaConcluida);
        Task Atualizar(UsuarioAulaConcluida usuarioAulaConcluida);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
