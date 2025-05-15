using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosItensTrustedMap : IEntityTypeConfiguration<LinxMovimentoRemessasAcertosItens>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessasAcertosItens> builder)
        {
            builder.ToTable("LinxMovimentoRemessasAcertosItens", "linx_microvix_erp");

            builder.HasKey(e => e.id_remessas_acertos);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessas_acertos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.qtde_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");

            builder.Property(e => e.id_remessas_itens)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoRemessasAcertosItensRawMap : IEntityTypeConfiguration<LinxMovimentoRemessasAcertosItens>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessasAcertosItens> builder)
        {
            builder.ToTable("LinxMovimentoRemessasAcertosItens", "untreated");

            builder.HasKey(e => e.id_remessas_acertos);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessas_acertos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.qtde_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");

            builder.Property(e => e.id_remessas_itens)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
