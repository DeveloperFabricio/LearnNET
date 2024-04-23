using LearnNET.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.NomeCompleto).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Senha).IsRequired();
            builder.Property(u => u.DataNascimento).IsRequired();
            builder.Property(u => u.Documento).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Celular).HasMaxLength(20);

            // Configuração da relação com a assinatura.
            builder.HasOne(u => u.Assinatura)
                   .WithMany(a => a.Usuarios)
                   .HasForeignKey(u => u.AssinaturaId) 
                   .OnDelete(DeleteBehavior.Restrict); // restringir a remoção da assinatura, se houver usuários vinculados a ela.
        }
    
    }
}
