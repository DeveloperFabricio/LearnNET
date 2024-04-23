using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class AulaRepository : IAulaRepository
    {
        private readonly AppDbContext _appDbContext;

        public AulaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(Aula aula)
        {
            await _appDbContext.Aulas.AddAsync(aula);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Aula aula)
        {
            _appDbContext.Aulas.Update(aula);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Aula> ObterPorId(int id)
        {
            return await _appDbContext.Aulas.AsNoTracking().Include(a => a.Id).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Aula>> ObterTodas()
        {
            return await _appDbContext.Aulas.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var aula = await ObterPorId(id);
                _appDbContext.Aulas.Remove(aula);
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
