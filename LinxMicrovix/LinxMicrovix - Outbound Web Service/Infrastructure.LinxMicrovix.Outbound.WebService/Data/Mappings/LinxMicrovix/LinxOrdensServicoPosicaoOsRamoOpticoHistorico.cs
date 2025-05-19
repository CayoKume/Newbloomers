using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistoricoMap : IEntityTypeConfiguration<LinxOrdensServicoPosicaoOsRamoOpticoHistorico>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> builder)
        {
            builder.ToTable("LinxOrdensServicoPosicaoOsRamoOpticoHistorico");

            builder.HasKey(e => e.id_ordens_servico_posicao_os_ramo_optico_historico);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_ordens_servico_posicao_os_ramo_optico_historico)
                .HasColumnType("int");

            builder.Property(e => e.numero_os)
                .HasColumnType("int");

            builder.Property(e => e.usuario)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");

            builder.Property(e => e.id_posicao_os_ramo_optico)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.observacao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.portal)
                .HasColumnType("bigint");
        }
    }
}
