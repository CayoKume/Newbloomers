using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxValeOrdemServicoExternaTrustedMap : IEntityTypeConfiguration<LinxValeOrdemServicoExterna>
    {
        public void Configure(EntityTypeBuilder<LinxValeOrdemServicoExterna> builder)
        {
            builder.ToTable("LinxValeOrdemServicoExterna", "linx_microvix_erp");

            builder.HasKey(e => e.id_vale_ordem_servico_externa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_vale_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.numero_controle)
                .HasColumnType("varchar(25)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxValeOrdemServicoExternaRawMap : IEntityTypeConfiguration<LinxValeOrdemServicoExterna>
    {
        public void Configure(EntityTypeBuilder<LinxValeOrdemServicoExterna> builder)
        {
            builder.ToTable("LinxValeOrdemServicoExterna", "untreated");

            builder.HasKey(e => e.id_vale_ordem_servico_externa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_vale_ordem_servico_externa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.numero_controle)
                .HasColumnType("varchar(25)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
