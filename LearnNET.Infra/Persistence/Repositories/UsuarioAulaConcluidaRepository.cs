using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class UsuarioAulaConcluidaRepository : IUsuarioAulaConcluidaRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioAulaConcluidaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(UsuarioAulaConcluida usuarioAulaConcluida)
        {
            await _appDbContext.UsuarioAulaConcluidas.AddAsync(usuarioAulaConcluida);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(UsuarioAulaConcluida usuarioAulaConcluida)
        {
            _appDbContext.UsuarioAulaConcluidas.Update(usuarioAulaConcluida);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<UsuarioAulaConcluida> ObterPorId(int id)
        {
            return await _appDbContext.UsuarioAulaConcluidas.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<UsuarioAulaConcluida>> ObterTodas()
        {
            return await _appDbContext.UsuarioAulaConcluidas.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var usuarioAulaConcluida = await ObterPorId(id);
                _appDbContext.UsuarioAulaConcluidas.Remove(usuarioAulaConcluida);
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
