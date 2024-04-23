using LearnNET.Core.Entities;

namespace LearnNET.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<Usuario> ObterPorId(int id);
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
