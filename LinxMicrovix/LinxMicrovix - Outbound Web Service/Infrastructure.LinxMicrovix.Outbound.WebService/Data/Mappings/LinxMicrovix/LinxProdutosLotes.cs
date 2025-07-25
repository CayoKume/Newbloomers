using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosLotesMap : IEntityTypeConfiguration<LinxProdutosLotes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosLotes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosLotes));

            builder.ToTable("LinxProdutosLotes");

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

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.lote)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo_disponivel)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
