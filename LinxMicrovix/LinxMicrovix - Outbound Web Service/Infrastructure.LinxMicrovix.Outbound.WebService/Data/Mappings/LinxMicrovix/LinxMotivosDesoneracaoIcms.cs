using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcmsMap : IEntityTypeConfiguration<LinxMotivosDesoneracaoIcms>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxMotivosDesoneracaoIcms> builder)
        {
            builder.ToTable("LinxMotivosDesoneracaoIcms");

            builder.HasKey(e => e.id_motivos_desoneracao_icms);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
