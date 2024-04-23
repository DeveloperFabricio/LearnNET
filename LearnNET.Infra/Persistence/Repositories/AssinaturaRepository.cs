using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class AssinaturaRepository : IAssinaturaRepository
    {
        private readonly AppDbContext _appDbContext;

        public AssinaturaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(Assinatura assinatura)
        {
            await _appDbContext.Assinaturas.AddAsync(assinatura);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Assinatura assinatura)
        {
            _appDbContext.Assinaturas.Update(assinatura);
            await _appDbContext.SaveChangesAsync();
            
        }

        public async Task<Assinatura> ObterPorId(int id)
        {
            return await _appDbContext.Assinaturas.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Assinatura>> ObterTodas()
        {
            return await _appDbContext.Assinaturas.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var assinatura = await ObterPorId(id);
                _appDbContext.Assinaturas.Remove(assinatura);
                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a deleção!");
            }
        }

        public async Task SaveChangesAsync()
        {
             await _appDbContext.SaveChangesAsync();
        }
    }
}
