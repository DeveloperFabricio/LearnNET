using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class PagamentoAssinaturaRepository : IPagamentoAssinaturaRepository
    {
        private readonly AppDbContext _appDbContext;

        public PagamentoAssinaturaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(PagamentoAssinatura pagamentoAssinatura)
        {
            await _appDbContext.PagamentoAssinaturas.AddAsync(pagamentoAssinatura);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(PagamentoAssinatura pagamentoAssinatura)
        {
            _appDbContext.PagamentoAssinaturas.Update(pagamentoAssinatura);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PagamentoAssinatura> ObterPorId(int id)
        {
            return await _appDbContext.PagamentoAssinaturas.AsNoTracking().Include(a => a.Id).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PagamentoAssinatura>> ObterTodos()
        {
            return await _appDbContext.PagamentoAssinaturas.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var pagamentoAssinatura = await ObterPorId(id);
                _appDbContext.PagamentoAssinaturas.Remove(pagamentoAssinatura);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao relizar a deleção!");
            }
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

    }
}
