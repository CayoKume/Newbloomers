using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistoricoMap : IEntityTypeConfiguration<LinxOrdensServicoPosicaoOsRamoOpticoHistorico>
    {
        public void Configure(EntityTypeBuilder<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOrdensServicoPosicaoOsRamoOpticoHistorico));

            builder.ToTable("LinxOrdensServicoPosicaoOsRamoOpticoHistorico");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_ordens_servico_posicao_os_ramo_optico_historico);
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
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.observacao)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.portal)
                .HasColumnType("bigint");
        }
    }
}
