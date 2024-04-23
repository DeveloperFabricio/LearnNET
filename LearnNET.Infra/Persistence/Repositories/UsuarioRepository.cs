using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Usuario usuario)
        {
            _appDbContext.Usuarios.Update(usuario);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            return await _appDbContext.Usuarios.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var usuario = await ObterPorId(id);
                _appDbContext.Usuarios.Remove(usuario);
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
