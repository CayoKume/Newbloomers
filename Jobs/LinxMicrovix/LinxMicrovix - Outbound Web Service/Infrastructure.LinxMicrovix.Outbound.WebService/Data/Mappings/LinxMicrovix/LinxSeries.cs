using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSeriesMap : IEntityTypeConfiguration<LinxSeries>
    {
        public void Configure(EntityTypeBuilder<LinxSeries> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxSeries));

            builder.ToTable("LinxSeries");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.serie);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
