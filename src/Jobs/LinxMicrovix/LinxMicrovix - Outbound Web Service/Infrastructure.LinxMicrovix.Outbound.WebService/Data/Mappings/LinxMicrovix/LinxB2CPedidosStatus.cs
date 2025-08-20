using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxB2CPedidosStatusMap : IEntityTypeConfiguration<LinxB2CPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<LinxB2CPedidosStatus> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxB2CPedidosStatus));

            builder.ToTable("LinxB2CPedidosStatus");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => new { e.id_pedido, e.id_status, e.id });
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_status)
                .HasColumnType("int");

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
