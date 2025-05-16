using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorTrustedMap : IEntityTypeConfiguration<B2CConsultaPedidosIdentificador>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosIdentificador> builder)
        {
            builder.ToTable("B2CConsultaPedidosIdentificador", "linx_microvix_commerce");

            builder.HasKey(e => new { e.identificador, e.id_venda, e.order_id, e.id_cliente });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.id_venda)
                .HasColumnType("int");

            builder.Property(e => e.order_id)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.id_cliente)
                .HasColumnType("int");

            builder.Property(e => e.valor_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class B2CConsultaPedidosIdentificadorRawMap : IEntityTypeConfiguration<B2CConsultaPedidosIdentificador>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosIdentificador> builder)
        {
            builder.ToTable("B2CConsultaPedidosIdentificador", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.id_venda)
                .HasColumnType("int");

            builder.Property(e => e.order_id)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.id_cliente)
                .HasColumnType("int");

            builder.Property(e => e.valor_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
