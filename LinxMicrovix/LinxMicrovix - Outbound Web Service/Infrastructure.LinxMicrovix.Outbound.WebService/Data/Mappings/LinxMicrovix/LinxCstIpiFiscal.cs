using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCstIpiFiscalMap : IEntityTypeConfiguration<LinxCstIpiFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstIpiFiscal> builder)
        {
            builder.ToTable("LinxCstIpiFiscal", "linx_microvix_erp");

            builder.HasKey(e => e.id_cst_ipi_fiscal);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_ipi_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cst_ipi_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.inicio_vigencia)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.termino_vigencia)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cst_ipi_fiscal_inverso)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxCstIpiFiscalRawMap : IEntityTypeConfiguration<LinxCstIpiFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstIpiFiscal> builder)
        {
            builder.ToTable("LinxCstIpiFiscal", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_ipi_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cst_ipi_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.inicio_vigencia)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.termino_vigencia)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cst_ipi_fiscal_inverso)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
