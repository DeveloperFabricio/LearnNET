using LearnNET.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class AssinaturaConfiguration : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable("Assinaturas");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(100);

            // Se desejar excluir as assinaturas quando não houver mais usuários vinculados a elas, descomente a linha abaixo
            // builder.HasMany(a => a.Usuarios)
            //        .WithOne(u => u.Assinatura)
            //        .HasForeignKey(u => u.AssinaturaId)
            //        .OnDelete(DeleteBehavior.Cascade);

            // verei isso mais a frente.
        }
    }
}
