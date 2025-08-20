using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosStatusMap : IEntityTypeConfiguration<B2CConsultaPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosStatus> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPedidosStatus));

            builder.ToTable("B2CConsultaPedidosStatus");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => new { e.id, e.id_pedido });
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_status)
                .HasProviderColumnType(EnumTableColumnType.TinyInt);

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.data_hora)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.anotacao)
                .HasColumnType("varchar(80)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
