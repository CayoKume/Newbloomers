using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdemServicoExternaDavMap : IEntityTypeConfiguration<LinxOrdemServicoExternaDav>
    {
        public void Configure(EntityTypeBuilder<LinxOrdemServicoExternaDav> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOrdemServicoExternaDav));

            builder.ToTable("LinxOrdemServicoExternaDav");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_vendas_pos_tmp_ordem_servico_externa);
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

            builder.Property(e => e.id_vendas_pos_tmp_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.id_vendas_pos)
                .HasColumnType("int");

            builder.Property(e => e.codigo_ordem_servico_externa)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
