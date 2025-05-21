using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcmsMap : IEntityTypeConfiguration<LinxMotivosDesoneracaoIcms>
    {
        public void Configure(EntityTypeBuilder<LinxMotivosDesoneracaoIcms> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMotivosDesoneracaoIcms));

            builder.ToTable("LinxMotivosDesoneracaoIcms");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_motivos_desoneracao_icms);
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

            builder.Property(e => e.id_motivos_desoneracao_icms)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
