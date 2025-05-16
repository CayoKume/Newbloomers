using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosStatusTrustedMap : IEntityTypeConfiguration<B2CConsultaPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosStatus> builder)
        {
            builder.ToTable("B2CConsultaPedidosStatus", "linx_microvix_commerce");

            builder.HasKey(e => new { e.id, e.id_pedido });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_status)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

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

    public class B2CConsultaPedidosStatusRawMap : IEntityTypeConfiguration<B2CConsultaPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosStatus> builder)
        {
            builder.ToTable("B2CConsultaPedidosStatus", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_status)
                .HasProviderColumnType(LogicalColumnType.TinyInt);

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
}
