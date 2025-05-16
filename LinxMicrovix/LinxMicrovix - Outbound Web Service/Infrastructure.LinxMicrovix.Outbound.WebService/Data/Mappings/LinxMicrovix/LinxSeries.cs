using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSeriesMap : IEntityTypeConfiguration<LinxSeries>
    {
        public void Configure(EntityTypeBuilder<LinxSeries> builder)
        {
            builder.ToTable("LinxSeries", "linx_microvix_erp");

            builder.HasKey(e => e.serie);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_modelo_nf)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxSeriesRawMap : IEntityTypeConfiguration<LinxSeries>
    {
        public void Configure(EntityTypeBuilder<LinxSeries> builder)
        {
            builder.ToTable("LinxSeries", "untread");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_modelo_nf)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
