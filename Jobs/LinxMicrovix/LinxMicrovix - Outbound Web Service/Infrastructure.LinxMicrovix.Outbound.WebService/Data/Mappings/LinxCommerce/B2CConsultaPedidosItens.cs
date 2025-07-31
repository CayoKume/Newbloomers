using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosItensMap : IEntityTypeConfiguration<B2CConsultaPedidosItens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosItens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPedidosItens));

            builder.ToTable("B2CConsultaPedidosItens");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.id_pedido_item, e.id_pedido, e.codigoproduto });
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

            builder.Property(e => e.id_pedido_item)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.quantidade)
                .HasColumnType("int");

            builder.Property(e => e.vl_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
