using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxFaturasOrigemMap : IEntityTypeConfiguration<LinxFaturasOrigem>
    {
        public void Configure(EntityTypeBuilder<LinxFaturasOrigem> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxFaturasOrigem));

            builder.ToTable("LinxFaturasOrigem");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.codigo_fatura_origem);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_fatura)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_fatura_origem)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
