using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExternaTrustedMap : IEntityTypeConfiguration<LinxMovimentoOrdemServicoExterna>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoOrdemServicoExterna> builder)
        {
            builder.ToTable("LinxMovimentoOrdemServicoExterna", "linx_microvix_erp");

            builder.HasKey(e => e.id_movimento_ordem_servico_externa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.codigo_ordem_servico)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoOrdemServicoExternaRawMap : IEntityTypeConfiguration<LinxMovimentoOrdemServicoExterna>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoOrdemServicoExterna> builder)
        {
            builder.ToTable("LinxMovimentoOrdemServicoExterna", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.codigo_ordem_servico)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
