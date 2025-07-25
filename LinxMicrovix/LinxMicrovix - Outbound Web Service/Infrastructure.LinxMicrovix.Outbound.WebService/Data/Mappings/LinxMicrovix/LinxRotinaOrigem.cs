using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRotinaOrigemMap : IEntityTypeConfiguration<LinxRotinaOrigem>
    {
        public void Configure(EntityTypeBuilder<LinxRotinaOrigem> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxRotinaOrigem));

            builder.ToTable("LinxRotinaOrigem");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.codigo_rotina);
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

            builder.Property(e => e.codigo_rotina)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_rotina)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
