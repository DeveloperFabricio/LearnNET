using LearnNET.Core.Entities;

namespace LearnNET.Core.Repositories
{
    public interface IUsuarioAssinaturaRepository
    {
        Task<IEnumerable<UsuarioAssinatura>> ObterTodas();
        Task<UsuarioAssinatura> ObterPorId(int id);
        Task Adicionar(UsuarioAssinatura usuarioAssinatura);
        Task Atualizar(UsuarioAssinatura usuarioAssinatura);
        Task Remover(int id);
        Task SaveChangesAsync();
    }
}
