using Infrastructure.IntegrationsCore.Data.Schemas;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxB2CStatusMap : IEntityTypeConfiguration<LinxB2CStatus>
    {
        public void Configure(EntityTypeBuilder<LinxB2CStatus> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxB2CStatus));

            builder.ToTable("LinxB2CStatus");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.id_status });
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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_status)
                .HasColumnType("int");

            builder.Property(e => e.descricao_status)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
