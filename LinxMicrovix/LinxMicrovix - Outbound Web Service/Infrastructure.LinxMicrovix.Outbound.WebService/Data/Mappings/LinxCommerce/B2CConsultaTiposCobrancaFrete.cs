using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteMap : IEntityTypeConfiguration<B2CConsultaTiposCobrancaFrete>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaTiposCobrancaFrete> builder)
        {
            builder.ToTable("B2CConsultaTiposCobrancaFrete");

            builder.HasKey(e => e.codigo_tipo_cobranca_frete);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_tipo_cobranca_frete)
                .HasColumnType("int");

            builder.Property(e => e.nome_tipo_cobranca_frete)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
