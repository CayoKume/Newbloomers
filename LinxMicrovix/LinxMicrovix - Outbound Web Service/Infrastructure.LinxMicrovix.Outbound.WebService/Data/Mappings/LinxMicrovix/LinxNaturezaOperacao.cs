using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNaturezaOperacaoMap : IEntityTypeConfiguration<LinxNaturezaOperacao>
    {
        public void Configure(EntityTypeBuilder<LinxNaturezaOperacao> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxNaturezaOperacao));

            builder.ToTable("LinxNaturezaOperacao");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_natureza_operacao);
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
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.calcula_iss)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.calcula_irrf)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.tipo_preco)
                .HasColumnType("char(2)");

            builder.Property(e => e.atualiza_custo)
                .HasColumnType("char(1)");

            builder.Property(e => e.transferencia)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.baixar_estoque)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.consumo_proprio)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.contabiliza_cmv)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.despesa)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.atualiza_custo_medio)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.exige_nf_origem)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.integra_contabilidade)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.venda_futura)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.base_icms_considera_ipi)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.permite_escolha_historico)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.import_produtos)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.deposito_reserva_venda)
                .HasColumnType("int");

            builder.Property(e => e.exibe_nfe)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.faturamento_antecipado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.exibir_informacoes_imposto)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.gera_garantia_nacional)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.transferencia_deposito)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.venda_diferencial_aliquota)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.insere_obs_pis_cofins)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.diferencial_ativo_consumo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.recusa_de)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
