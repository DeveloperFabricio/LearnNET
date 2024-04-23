using static LearnNET.Infra.Persistence.UnitOfWork;

namespace LearnNET.Infra.Persistence
{
    public interface IUnitOfWork
    {
        Task<bool> Sucesso();
        Task<ResultadoOperacao> MensagemErro();
        Task<int> SaveChangesAsync();
        Task<int> CommitAsync();
        Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
