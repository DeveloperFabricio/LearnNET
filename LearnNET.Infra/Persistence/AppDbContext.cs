using LearnNET.Core.Entities;
using LearnNET.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<PagamentoAssinatura> PagamentoAssinaturas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioAssinatura> UsuarioAssinaturas { get; set; }
        public DbSet<UsuarioAulaConcluida> UsuarioAulaConcluidas { get; set; }

        public void ConcluirAulaComNota(int idUsuario, int idAula, int nota)
        {
            // Verificar se a aula já foi concluída pelo usuário
            var aulaConcluida = UsuarioAulaConcluidas.FirstOrDefault(uac => uac.IdUsuario == idUsuario && uac.IdAula == idAula);

            if (aulaConcluida != null)
            {
                // A aula já foi concluída pelo usuário, atualize a nota
                aulaConcluida.Nota = nota;
                aulaConcluida.DataConclusao = DateTime.Now; // Atualize a data de conclusão se necessário
            }
            else
            {
                // A aula ainda não foi concluída pelo usuário, crie uma nova entrada
                aulaConcluida = new UsuarioAulaConcluida
                {
                    IdUsuario = idUsuario,
                    IdAula = idAula,
                    Nota = nota,
                    DataConclusao = DateTime.Now // Defina a data atual
                };

                UsuarioAulaConcluidas.Add(aulaConcluida);
            }

            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssinaturaConfiguration());
            modelBuilder.ApplyConfiguration(new AulaConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new ModuloConfiguration());
            modelBuilder.ApplyConfiguration(new PagamentoAssinaturaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioAssinaturaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioAulaConcluidaConfiguration());
        }
    }
}
