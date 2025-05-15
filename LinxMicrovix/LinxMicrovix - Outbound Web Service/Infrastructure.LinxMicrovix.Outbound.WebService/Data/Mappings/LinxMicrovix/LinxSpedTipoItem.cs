using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSpedTipoItemTrustedMap : IEntityTypeConfiguration<LinxSpedTipoItem>
    {
        public void Configure(EntityTypeBuilder<LinxSpedTipoItem> builder)
        {
            builder.ToTable("LinxSpedTipoItem", "linx_microvix_erp");

            builder.HasKey(e => e.id_sped_tipo_item);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_sped_tipo_item)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxSpedTipoItemRawMap : IEntityTypeConfiguration<LinxSpedTipoItem>
    {
        public void Configure(EntityTypeBuilder<LinxSpedTipoItem> builder)
        {
            builder.ToTable("LinxSpedTipoItem", "untreated");

            builder.HasKey(e => e.id_sped_tipo_item);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_sped_tipo_item)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
