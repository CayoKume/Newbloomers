using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCstIcmsFiscalMap : IEntityTypeConfiguration<LinxCstIcmsFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstIcmsFiscal> builder)
        {
            builder.ToTable("LinxCstIcmsFiscal", "linx_microvix_erp");

            builder.HasKey(e => e.id_cst_icms_fiscal);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_icms_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cst_icms_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.substituicao_tributaria)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxCstIcmsFiscalRawMap : IEntityTypeConfiguration<LinxCstIcmsFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstIcmsFiscal> builder)
        {
            builder.ToTable("LinxCstIcmsFiscal", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_icms_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.cst_icms_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.substituicao_tributaria)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.excluido)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
