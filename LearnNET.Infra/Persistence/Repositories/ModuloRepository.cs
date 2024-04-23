using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly AppDbContext _appDbContext;

        public ModuloRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(Modulo modulo)
        {
            await _appDbContext.Modulos.AddAsync(modulo);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Modulo modulo)
        {
            _appDbContext.Modulos.Update(modulo);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Modulo> ObterPorId(int id)
        {
            return await _appDbContext.Modulos.AsNoTracking().Include(a => a.Id).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Modulo>> ObterTodos()
        {
            return await _appDbContext.Modulos.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var modulo = await ObterPorId(id);
                _appDbContext.Modulos.Remove(modulo);
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
