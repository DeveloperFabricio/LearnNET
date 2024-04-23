using LearnNET.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("Modulos");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Descricao).IsRequired();
            builder.Property(m => m.DataCriacao).IsRequired();

            // Configurando relação de Módulo com Aulas
            builder.HasMany(m => m.Aulas)
                   .WithOne()
                   .HasForeignKey(a => a.ModuloId);
        }
    
    }
}
