using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaCodigoRastreioMap : IEntityTypeConfiguration<B2CConsultaCodigoRastreio>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaCodigoRastreio> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaCodigoRastreio));

            builder.ToTable("B2CConsultaCodigoRastreio");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_pedido);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
