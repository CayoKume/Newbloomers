using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcmsMap : IEntityTypeConfiguration<LinxMotivosDesoneracaoIcms>
    {
        public void Configure(EntityTypeBuilder<LinxMotivosDesoneracaoIcms> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMotivosDesoneracaoIcms));

            builder.ToTable("LinxMotivosDesoneracaoIcms");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_motivos_desoneracao_icms);
            

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
