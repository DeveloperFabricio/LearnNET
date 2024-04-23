using LearnNET.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class UsuarioAulaConcluidaConfiguration : IEntityTypeConfiguration<UsuarioAulaConcluida>
    {
        public void Configure(EntityTypeBuilder<UsuarioAulaConcluida> builder)
        {
            builder.ToTable("UsuariosAulasConcluidas");
            builder.HasKey(uac => new { uac.IdUsuario, uac.IdAula });
            builder.Property(uac => uac.DataConclusao).IsRequired();
            builder.Property(uac => uac.Nota).IsRequired(); // Configuração da propriedade Nota
            builder.HasOne(uac => uac.Usuario).WithMany().HasForeignKey(uac => uac.IdUsuario);
            builder.HasOne(uac => uac.Aula).WithMany().HasForeignKey(uac => uac.IdAula);

        }
    
    }
}
