using Microsoft.Extensions.Logging;

namespace LearnNET.Infra.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(AppDbContext appDbContext, ILogger<UnitOfWork> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _appDbContext.Set<TEntity>().Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<ResultadoOperacao> MensagemErro()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();
                return ResultadoOperacao.Sucesso;
            }
            catch (Exception)
            {
                return ResultadoOperacao.Erro;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> Sucesso()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar alterações no banco de dados.");
                return false;
            }
        }

        public enum ResultadoOperacao
        {
            Sucesso,
            Erro
        }
    }
}
