using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxLotesProdutosMap : IEntityTypeConfiguration<LinxLotesProdutos>
    {
        public void Configure(EntityTypeBuilder<LinxLotesProdutos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxLotesProdutos));

            builder.ToTable("LinxLotesProdutos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_lote);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_lote)
                .HasColumnType("int");

            builder.Property(e => e.codigo_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.lote)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.data_fabricacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_vencimento)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
