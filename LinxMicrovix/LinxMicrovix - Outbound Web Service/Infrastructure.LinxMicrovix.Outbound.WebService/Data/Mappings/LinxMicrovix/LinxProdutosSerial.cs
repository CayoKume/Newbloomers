using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosSerialMap : IEntityTypeConfiguration<LinxProdutosSerial>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosSerial> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosSerial));

            builder.ToTable("LinxProdutosSerial");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.codigoproduto);
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

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.serial)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
