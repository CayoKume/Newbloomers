using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorMap : IEntityTypeConfiguration<B2CConsultaPedidosIdentificador>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosIdentificador> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPedidosIdentificador));

            builder.ToTable("B2CConsultaPedidosIdentificador");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.identificador, e.id_venda, e.order_id, e.id_cliente });
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

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.id_venda)
                .HasColumnType("int");

            builder.Property(e => e.order_id)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.id_cliente)
                .HasColumnType("int");

            builder.Property(e => e.valor_frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_origem)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
