using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCestMap : IEntityTypeConfiguration<LinxCest>
    {
        public void Configure(EntityTypeBuilder<LinxCest> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCest));

            builder.ToTable("LinxCest");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.id_cest });
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

            builder.Property(e => e.id_cest)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(700)");

            builder.Property(e => e.cest)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_segmento_mercadoria_bem)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
