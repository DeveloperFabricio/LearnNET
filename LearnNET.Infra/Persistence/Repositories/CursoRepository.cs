using LearnNET.Core.Entities;
using LearnNET.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _appDbContext;

        public CursoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Adicionar(Curso curso)
        {
            await _appDbContext.Cursos.AddAsync(curso);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Curso curso)
        {
            _appDbContext.Cursos.Update(curso);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Curso> ObterPorId(int id)
        {
            return await _appDbContext.Cursos.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Curso>> ObterTodos()
        {
            return await _appDbContext.Cursos.ToListAsync();
        }

        public async Task Remover(int id)
        {
            try
            {
                var curso = await ObterPorId(id);
                _appDbContext.Cursos.Remove(curso);
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
