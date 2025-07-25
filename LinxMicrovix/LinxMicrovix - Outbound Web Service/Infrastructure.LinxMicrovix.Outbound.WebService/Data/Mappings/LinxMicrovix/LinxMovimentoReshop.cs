using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoReshopMap : IEntityTypeConfiguration<LinxMovimentoReshop>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoReshop> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoReshop));

            builder.ToTable("LinxMovimentoReshop");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.identificador);
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

            builder.Property(e => e.id_movimento_campanha_reshop)
                .HasColumnType("int");

            builder.Property(e => e.id_campanha)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.nome)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.aplicar_desconto_venda)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.valor_desconto_subtotal)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_desconto_completo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
