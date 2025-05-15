using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxB2CPedidosStatusTrustedMap : IEntityTypeConfiguration<LinxB2CPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<LinxB2CPedidosStatus> builder)
        {
            builder.ToTable("LinxB2CPedidosStatus", "linx_microvix_erp");

            builder.HasKey(e => e.id);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_status)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.data_hora)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.anotacao)
                .HasColumnType("varchar(80)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class LinxB2CPedidosStatusRawMap : IEntityTypeConfiguration<LinxB2CPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<LinxB2CPedidosStatus> builder)
        {
            throw new NotImplementedException();
        }
    }
}
