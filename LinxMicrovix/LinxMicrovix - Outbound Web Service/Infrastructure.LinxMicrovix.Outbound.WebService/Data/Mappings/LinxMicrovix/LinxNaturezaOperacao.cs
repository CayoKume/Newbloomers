using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNaturezaOperacaoTrustedMap : IEntityTypeConfiguration<LinxNaturezaOperacao>
    {
        public void Configure(EntityTypeBuilder<LinxNaturezaOperacao> builder)
        {
            builder.ToTable("LinxNaturezaOperacao", "linx_microvix_erp");

            builder.HasKey(e => e.cod_natureza_operacao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("char(10)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.soma_relatorios)
                .HasColumnType("char(1)");

            builder.Property(e => e.operacao)
                .HasColumnType("char(2)");

            builder.Property(e => e.inativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.calcula_ipi)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.calcula_iss)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.calcula_irrf)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.tipo_preco)
                .HasColumnType("char(2)");

            builder.Property(e => e.atualiza_custo)
                .HasColumnType("char(1)");

            builder.Property(e => e.transferencia)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.baixar_estoque)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.consumo_proprio)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.contabiliza_cmv)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.despesa)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.atualiza_custo_medio)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.exige_nf_origem)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.integra_contabilidade)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.venda_futura)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.base_icms_considera_ipi)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.permite_escolha_historico)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.import_produtos)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.deposito_reserva_venda)
                .HasColumnType("int");

            builder.Property(e => e.exibe_nfe)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.faturamento_antecipado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.exibir_informacoes_imposto)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.gera_garantia_nacional)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.transferencia_deposito)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.venda_diferencial_aliquota)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.insere_obs_pis_cofins)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.diferencial_ativo_consumo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.recusa_de)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");
        }
    }

    public class LinxNaturezaOperacaoRawMap : IEntityTypeConfiguration<LinxNaturezaOperacao>
    {
        public void Configure(EntityTypeBuilder<LinxNaturezaOperacao> builder)
        {
            builder.ToTable("LinxNaturezaOperacao", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("char(10)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.soma_relatorios)
                .HasColumnType("char(1)");

            builder.Property(e => e.operacao)
                .HasColumnType("char(2)");

            builder.Property(e => e.inativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.calcula_ipi)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.calcula_iss)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.calcula_irrf)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.tipo_preco)
                .HasColumnType("char(2)");

            builder.Property(e => e.atualiza_custo)
                .HasColumnType("char(1)");

            builder.Property(e => e.transferencia)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.baixar_estoque)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.consumo_proprio)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.contabiliza_cmv)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.despesa)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.atualiza_custo_medio)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.exige_nf_origem)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.integra_contabilidade)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.venda_futura)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.base_icms_considera_ipi)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.permite_escolha_historico)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.import_produtos)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.deposito_reserva_venda)
                .HasColumnType("int");

            builder.Property(e => e.exibe_nfe)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.faturamento_antecipado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.exibir_informacoes_imposto)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.gera_garantia_nacional)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.transferencia_deposito)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.venda_diferencial_aliquota)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.insere_obs_pis_cofins)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.diferencial_ativo_consumo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.recusa_de)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
