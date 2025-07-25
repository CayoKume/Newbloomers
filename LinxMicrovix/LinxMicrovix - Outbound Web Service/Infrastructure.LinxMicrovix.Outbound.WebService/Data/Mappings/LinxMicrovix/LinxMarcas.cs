using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMarcasMap : IEntityTypeConfiguration<LinxMarcas>
    {
        public void Configure(EntityTypeBuilder<LinxMarcas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMarcas));

            builder.ToTable("LinxMarcas");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_marca);
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

            builder.Property(e => e.id_marca)
                .HasColumnType("int");

            builder.Property(e => e.desc_marca)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
