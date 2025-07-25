using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMotivoDevolucaoMap : IEntityTypeConfiguration<LinxMotivoDevolucao>
    {
        public void Configure(EntityTypeBuilder<LinxMotivoDevolucao> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMotivoDevolucao));

            builder.ToTable("LinxMotivoDevolucao");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_motivo);
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

            builder.Property(e => e.cod_motivo)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_motivo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_deposito)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
