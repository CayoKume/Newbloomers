using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExternaMap : IEntityTypeConfiguration<LinxMovimentoOrdemServicoExterna>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoOrdemServicoExterna> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoOrdemServicoExterna));

            builder.ToTable("LinxMovimentoOrdemServicoExterna");
            
            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_movimento_ordem_servico_externa);
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

            builder.Property(e => e.id_movimento_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.Property(e => e.codigo_ordem_servico)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
