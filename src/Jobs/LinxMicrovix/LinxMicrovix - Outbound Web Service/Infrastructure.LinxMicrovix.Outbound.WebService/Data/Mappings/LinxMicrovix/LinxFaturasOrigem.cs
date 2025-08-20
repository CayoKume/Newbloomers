using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxFaturasOrigemMap : IEntityTypeConfiguration<LinxFaturasOrigem>
    {
        public void Configure(EntityTypeBuilder<LinxFaturasOrigem> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxFaturasOrigem));

            builder.ToTable("LinxFaturasOrigem");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.codigo_fatura_origem);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigo_fatura)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_fatura_origem)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
