using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdemServicoExternaDavTrustedMap : IEntityTypeConfiguration<LinxOrdemServicoExternaDav>
    {
        public void Configure(EntityTypeBuilder<LinxOrdemServicoExternaDav> builder)
        {
            builder.ToTable("LinxOrdemServicoExternaDav", "linx_microvix_erp");

            builder.HasKey(e => e.id_vendas_pos_tmp_ordem_servico_externa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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

    public class LinxOrdemServicoExternaDavRawMap : IEntityTypeConfiguration<LinxOrdemServicoExternaDav>
    {
        public void Configure(EntityTypeBuilder<LinxOrdemServicoExternaDav> builder)
        {
            builder.ToTable("LinxOrdemServicoExternaDav", "untreated");

            builder.HasKey(e => e.id_vendas_pos_tmp_ordem_servico_externa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
