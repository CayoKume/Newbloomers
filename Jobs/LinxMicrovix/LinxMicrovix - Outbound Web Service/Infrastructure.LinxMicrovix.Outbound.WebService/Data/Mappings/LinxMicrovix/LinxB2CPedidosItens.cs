using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxB2CPedidosItensMap : IEntityTypeConfiguration<LinxB2CPedidosItens>
    {
        public void Configure(EntityTypeBuilder<LinxB2CPedidosItens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxB2CPedidosItens));

            builder.ToTable("LinxB2CPedidosItens");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.id_pedido_item, e.id_pedido, e.codigoproduto });
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

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
