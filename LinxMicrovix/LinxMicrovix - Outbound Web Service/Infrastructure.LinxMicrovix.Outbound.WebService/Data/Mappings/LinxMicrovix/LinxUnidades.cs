using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxUnidadesMap : IEntityTypeConfiguration<LinxUnidades>
    {
        public void Configure(EntityTypeBuilder<LinxUnidades> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxUnidades));

            builder.ToTable("LinxUnidades");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.idUnidade);
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

            builder.Property(e => e.idUnidade)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
