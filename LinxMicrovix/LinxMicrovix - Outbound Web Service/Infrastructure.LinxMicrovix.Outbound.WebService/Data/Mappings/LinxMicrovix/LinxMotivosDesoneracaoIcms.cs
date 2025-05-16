using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcmsTrustedMap : IEntityTypeConfiguration<LinxMotivosDesoneracaoIcms>
    {
        public void Configure(EntityTypeBuilder<LinxMotivosDesoneracaoIcms> builder)
        {
            builder.ToTable("LinxMotivosDesoneracaoIcms", "linx_microvix_erp");

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

    public class LinxMotivosDesoneracaoIcmsRawMap : IEntityTypeConfiguration<LinxMotivosDesoneracaoIcms>
    {
        public void Configure(EntityTypeBuilder<LinxMotivosDesoneracaoIcms> builder)
        {
            builder.ToTable("LinxMotivosDesoneracaoIcms", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

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
