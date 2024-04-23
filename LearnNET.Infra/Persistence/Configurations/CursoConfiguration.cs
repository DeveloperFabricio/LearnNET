using LearnNET.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Cursos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Descricao).IsRequired();
            builder.Property(c => c.DataCriacao).IsRequired();

            // Configurar relação de Curso com Modulos
            builder.HasMany(c => c.Modulos)
                   .WithOne()
                   .HasForeignKey(m => m.CursoId);
        }
    
    }
}
