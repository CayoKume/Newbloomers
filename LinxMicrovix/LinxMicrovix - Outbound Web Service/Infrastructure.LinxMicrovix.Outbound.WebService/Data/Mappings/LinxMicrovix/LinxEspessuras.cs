using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxEspessurasTrustedMap : IEntityTypeConfiguration<LinxEspessuras>
    {
        public void Configure(EntityTypeBuilder<LinxEspessuras> builder)
        {
            builder.ToTable("LinxEspessuras", "linx_microvix_erp");

            builder.HasKey(e => e.id_espessura);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_espessura)
                .HasColumnType("int");

            builder.Property(e => e.desc_espessura)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }

    public class LinxEspessurasRawMap : IEntityTypeConfiguration<LinxEspessuras>
    {
        public void Configure(EntityTypeBuilder<LinxEspessuras> builder)
        {
            builder.ToTable("LinxEspessuras", "untreated");

            builder.HasKey(e => e.id_espessura);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_espessura)
                .HasColumnType("int");

            builder.Property(e => e.desc_espessura)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }
}
