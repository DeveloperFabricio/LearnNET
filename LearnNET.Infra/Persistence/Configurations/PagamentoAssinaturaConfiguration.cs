using LearnNET.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearnNET.Infra.Persistence.Configurations
{
    public class PagamentoAssinaturaConfiguration : IEntityTypeConfiguration<PagamentoAssinatura>
    {
        public void Configure(EntityTypeBuilder<PagamentoAssinatura> builder)
        {
            builder.ToTable("PagamentosAssinatura");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DataProcessamento).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.DataVencimento).IsRequired();
            builder.HasIndex(p => p.IdExternoPagamento).IsUnique();
        }
    
    }
}
