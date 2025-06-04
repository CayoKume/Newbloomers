using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoReshopItensMap : IEntityTypeConfiguration<LinxMovimentoReshopItens>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoReshopItens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoReshopItens));

            builder.ToTable("LinxMovimentoReshopItens");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_movimento_campanha_reshop_item);
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

            builder.Property(e => e.id_movimento_campanha_reshop_item)
                .HasColumnType("int");

            builder.Property(e => e.id_campanha)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.valor_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desconto_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_original)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.ordem)
                .HasColumnType("int");
        }
    }
}
