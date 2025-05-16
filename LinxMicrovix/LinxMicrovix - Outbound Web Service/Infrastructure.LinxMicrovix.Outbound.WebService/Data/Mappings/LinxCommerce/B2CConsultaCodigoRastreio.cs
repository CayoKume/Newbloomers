using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaCodigoRastreioMap : IEntityTypeConfiguration<B2CConsultaCodigoRastreio>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaCodigoRastreio> builder)
        {
            builder.ToTable("B2CConsultaCodigoRastreio", "linx_microvix_commerce");

            builder.HasKey(e => e.id_pedido);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.codigo_rastreio)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.sequencia_volume)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
