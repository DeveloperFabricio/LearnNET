using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LearnNET.Core.Entities;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class UsuarioAssinaturaConfiguration : IEntityTypeConfiguration<UsuarioAssinatura>
    {
        public void Configure(EntityTypeBuilder<UsuarioAssinatura> builder)
        {
            builder.ToTable("UsuariosAssinatura");
            builder.HasKey(ua => ua.Id);
            builder.Property(ua => ua.DataInicio).IsRequired();
            builder.Property(ua => ua.DataExpiracao).IsRequired();
           
        }
    
    }
}
