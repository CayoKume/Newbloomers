using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPosicaoOsRamoOpticoMap : IEntityTypeConfiguration<LinxPosicaoOsRamoOptico>
    {
        public void Configure(EntityTypeBuilder<LinxPosicaoOsRamoOptico> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPosicaoOsRamoOptico));

            builder.ToTable("LinxPosicaoOsRamoOptico");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_posicao_os_ramo_optico);
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

            builder.Property(e => e.id_posicao_os_ramo_optico)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.codigo_status_padrao)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
