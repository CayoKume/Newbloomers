using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRamosAtividadeMap : IEntityTypeConfiguration<LinxRamosAtividade>
    {
        public void Configure(EntityTypeBuilder<LinxRamosAtividade> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxRamosAtividade));

            builder.ToTable("LinxRamosAtividade");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_ramo_atividade);
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

            builder.Property(e => e.id_ramo_atividade)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nome_ramo_atividade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.codigo_ramo_atividade)
                .HasColumnType("varchar(12)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
