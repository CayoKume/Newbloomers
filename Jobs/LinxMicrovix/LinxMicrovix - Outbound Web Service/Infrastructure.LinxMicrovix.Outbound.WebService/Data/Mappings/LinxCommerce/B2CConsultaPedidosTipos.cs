using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosTiposMap : IEntityTypeConfiguration<B2CConsultaPedidosTipos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosTipos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPedidosTipos));

            builder.ToTable("B2CConsultaPedidosTipos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_tipo_b2c);
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
