using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRemessasRetornoTiposMap : IEntityTypeConfiguration<LinxRemessasRetornoTipos>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasRetornoTipos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxRemessasRetornoTipos));

            builder.ToTable("LinxRemessasRetornoTipos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_remessa_retorno_tipos);
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

            builder.Property(e => e.id_remessa_retorno_tipos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
