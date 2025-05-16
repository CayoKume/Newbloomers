using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSpedTipoBaseCreditoTrustedMap : IEntityTypeConfiguration<LinxSpedTipoBaseCredito>
    {
        public void Configure(EntityTypeBuilder<LinxSpedTipoBaseCredito> builder)
        {
            builder.ToTable("LinxSpedTipoBaseCredito", "linx_microvix_erp");

            builder.HasKey(e => e.id_sped_tipo_base_credito);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_sped_tipo_base_credito)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo_sped_tipo_base_credito)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxSpedTipoBaseCreditoRawMap : IEntityTypeConfiguration<LinxSpedTipoBaseCredito>
    {
        public void Configure(EntityTypeBuilder<LinxSpedTipoBaseCredito> builder)
        {
            builder.ToTable("LinxSpedTipoBaseCredito", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_sped_tipo_base_credito)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo_sped_tipo_base_credito)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
