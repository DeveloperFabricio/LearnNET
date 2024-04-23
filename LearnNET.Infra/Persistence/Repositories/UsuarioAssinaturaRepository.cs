using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class UsuarioAssinaturaRepository : IUsuarioAssinaturaRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioAssinaturaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(Core.Entities.UsuarioAssinatura usuarioAssinatura)
        {
            await _appDbContext.UsuarioAssinaturas.AddAsync(usuarioAssinatura);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Core.Entities.UsuarioAssinatura usuarioAssinatura)
        {
           _appDbContext.UsuarioAssinaturas.Update(usuarioAssinatura);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Core.Entities.UsuarioAssinatura> ObterPorId(int id)
        {
            return await _appDbContext.UsuarioAssinaturas.AsNoTracking().Include(u => u.Id).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Core.Entities.UsuarioAssinatura>> ObterTodas()
        {
            return await _appDbContext.UsuarioAssinaturas.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var usuarioAssinatura = await ObterPorId(id);
                _appDbContext.UsuarioAssinaturas.Remove(usuarioAssinatura);
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