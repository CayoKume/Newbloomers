using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasItensTrustedMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoVendasItens>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoVendasItens> builder)
        {
            builder.ToTable("LinxTrocaUnificadaResumoVendasItens", "linx_microvix_erp");

            builder.HasKey(e => e.id_troca_unificada_resumo_vendas_itens);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_troca_unificada_resumo_vendas_itens)
                .HasColumnType("bigint");

            builder.Property(e => e.id_troca_unificada_resumo_vendas)
                .HasColumnType("bigint");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.serial)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor_liquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_validade)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.venda_referenciada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.token_utilizado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxTrocaUnificadaResumoVendasItensRawMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoVendasItens>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoVendasItens> builder)
        {
            builder.ToTable("LinxTrocaUnificadaResumoVendasItens", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_troca_unificada_resumo_vendas_itens)
                .HasColumnType("bigint");

            builder.Property(e => e.id_troca_unificada_resumo_vendas)
                .HasColumnType("bigint");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.serial)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor_liquido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.data_validade)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.venda_referenciada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.token_utilizado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
