using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCstCofinsFiscalMap : IEntityTypeConfiguration<LinxCstCofinsFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstCofinsFiscal> builder)
        {
            builder.ToTable("LinxCstCofinsFiscal", "linx_microvix_erp");

        builder.HasKey(e => e.id_csosn_fiscal);

        builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.portal)
            .HasColumnType("int");

        builder.Property(e => e.id_csosn_fiscal)
            .HasColumnType("int");

        builder.Property(e => e.csosn_fiscal)
            .HasColumnType("varchar(5)");

        builder.Property(e => e.descricao)
            .HasColumnType("varchar(200)");

        builder.Property(e => e.id_csosn_fiscal_substitutiva)
            .HasColumnType("int");

        builder.Property(e => e.timestamp)
            .HasColumnType("bigint");
        }
    }

    public class LinxCstCofinsFiscalRawMap : IEntityTypeConfiguration<LinxCstCofinsFiscal>
    {
        public void Configure(EntityTypeBuilder<LinxCstCofinsFiscal> builder)
        {
            builder.ToTable("LinxCstCofinsFiscal", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_csosn_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.csosn_fiscal)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.id_csosn_fiscal_substitutiva)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
