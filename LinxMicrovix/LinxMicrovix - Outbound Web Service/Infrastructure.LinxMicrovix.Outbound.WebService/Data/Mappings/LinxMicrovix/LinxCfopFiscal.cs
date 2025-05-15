using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCfopFiscalTrustedMap : IEntityTypeConfiguration<LinxCfopFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCfopFiscal> builder)
        {
            builder.ToTable("LinxCfopFiscal", "linx_microvix_erp");

            builder.HasKey(e => e.id_cfop_fiscal);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_cfop_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cfop_fiscal)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxCfopFiscalRawMap : IEntityTypeConfiguration<LinxCfopFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCfopFiscal> builder)
        {
            builder.ToTable("LinxCfopFiscal", "untreated");

        builder.HasKey(e => e.id_cfop_fiscal);

        builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.portal)
            .HasColumnType("int");

        builder.Property(e => e.id_cfop_fiscal)
            .HasColumnType("int");

        builder.Property(e => e.cfop_fiscal)
            .HasColumnType("varchar(5)");

        builder.Property(e => e.descricao)
            .HasColumnType("varchar(300)");

        builder.Property(e => e.excluido)
            .HasProviderColumnType(LogicalColumnType.Bool);

        builder.Property(e => e.timestamp)
            .HasColumnType("bigint");
        }
    }
}
