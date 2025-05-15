using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPosicaoOsRamoOpticoTrustedMap : IEntityTypeConfiguration<LinxPosicaoOsRamoOptico>
    {
        public void Configure(EntityTypeBuilder<LinxPosicaoOsRamoOptico> builder)
        {
            builder.ToTable("LinxPosicaoOsRamoOptico", "linx_microvix_erp");

    builder.HasKey(e => e.id_posicao_os_ramo_optico);

    builder.Property(e => e.lastupdateon)
        .HasProviderColumnType(LogicalColumnType.DateTime);

    builder.Property(e => e.id_posicao_os_ramo_optico)
        .HasColumnType("int");

    builder.Property(e => e.descricao)
        .HasColumnType("varchar(50)");

    builder.Property(e => e.codigo_status_padrao)
        .HasColumnType("int");

    builder.Property(e => e.ativo)
        .HasProviderColumnType(LogicalColumnType.Bool);

    builder.Property(e => e.timestamp)
        .HasColumnType("bigint");
        }
    }

    public class LinxPosicaoOsRamoOpticoRawMap : IEntityTypeConfiguration<LinxPosicaoOsRamoOptico>
    {
        public void Configure(EntityTypeBuilder<LinxPosicaoOsRamoOptico> builder)
        {
            builder.ToTable("LinxPosicaoOsRamoOptico", "untreated");

            builder.HasKey(e => e.id_posicao_os_ramo_optico);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_posicao_os_ramo_optico)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.codigo_status_padrao)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
