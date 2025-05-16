using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosTiposMap : IEntityTypeConfiguration<B2CConsultaPedidosTipos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosTipos> builder)
        {
            builder.ToTable("B2CConsultaPedidosTipos", "linx_microvix_commerce");

            builder.HasKey(e => e.id_tipo_b2c);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_tipo_b2c)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.pos_timestamp_old)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
