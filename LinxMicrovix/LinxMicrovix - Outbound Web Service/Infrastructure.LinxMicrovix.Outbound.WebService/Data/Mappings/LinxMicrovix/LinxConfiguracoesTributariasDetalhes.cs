using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasDetalhes>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasDetalhes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxConfiguracoesTributariasDetalhes));

            builder.ToTable("LinxConfiguracoesTributariasDetalhes");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_config_tributaria);
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

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.desc_classe_fiscal)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.cod_natureza_operacao)
                .HasColumnType("char(10)");

            builder.Property(e => e.desc_natureza_operacao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cfop_fiscal)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.desc_cfop_fiscal)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.aliq_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.valor_tributado_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_pis)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_cofins)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.perc_reducao_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.perc_reducao_icms_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.margem_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_st)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.margem_st_simulador)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_st_simulador)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cst_icms_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.desc_cst_icms_fiscal)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.cst_ipi_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.desc_cst_ipi_fiscal)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.cst_pis_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.desc_cst_pis_fiscal)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.cst_cofins_fiscal)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.desc_cst_cofins_fiscal)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.desc_obs_padrao)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.icms_credito)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.ipi_credito)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.cod_enquadramento_ipi)
                .HasColumnType("char(3)");

            builder.Property(e => e.desc_enquadramento_ipi)
                .HasColumnType("varchar(600)");

            builder.Property(e => e.perc_aliquota_interna_uf_destinatario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.perc_aliquota_interestadual_uf_envolvidas)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.csosn_fiscal)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.desc_csosn_fiscal)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.forma_tributacao_pis)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.forma_tributacao_cofins)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_ramo_atividade)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.usa_base_icms_para_calculo_st)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_classe_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cfop_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_icms_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_ipi_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_pis_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_cofins_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.id_obs)
                .HasColumnType("int");

            builder.Property(e => e.tributado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.retido)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.icms_base_naotributado)
                .HasColumnType("int");

            builder.Property(e => e.ipi_base_naotributado)
                .HasColumnType("int");

            builder.Property(e => e.id_csosn_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.somar_icms_st)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_sped_tipo_base_credito)
                .HasColumnType("int");

            builder.Property(e => e.aliq_pis_servico)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_cofins_servico)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_cst_pis_fiscal_servico)
                .HasColumnType("int");

            builder.Property(e => e.id_cst_cofins_fiscal_servico)
                .HasColumnType("int");

            builder.Property(e => e.csrf)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.codigo_retencao_csrf)
                .HasColumnType("varchar(4)");

            builder.Property(e => e.aliq_pis_csrf)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_cofins_csrf)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_csll_csrf)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_sped_tipo_base_credito_servico)
                .HasColumnType("int");

            builder.Property(e => e.receita)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.fci_informa_parcela_importada)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.fci_informa_numero)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.fci_informa_conteudo_importacao)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.fci_informa_valor_importacao)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.iss_tipo_tributacao)
                .HasColumnType("int");

            builder.Property(e => e.icms_st_antecipado_margem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_antecipado_aliquota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_antecipado_percentual_reducao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_st_antecipado_valor_integra_custo_medio)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_enquadramento_ipi)
                .HasColumnType("int");

            builder.Property(e => e.usa_regime_estimativa_simplifica)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.aliq_carga_tributaria_media)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.fcp_integra_custo_medio)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.aliq_fcp)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.fcp_credito)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.fcp_reducao_icms)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.aliq_icms_efetivo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.perc_reducao_icms_efetivo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.icms_fcp_st_antecipado_aliquota)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.difal_base_dupla)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.aliq_desoneracao_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliq_desoneracao_fcp)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cod_beneficio_fiscal)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_motivo_desoneracao_icms)
                .HasColumnType("int");

            builder.Property(e => e.deduzir_icms_custo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.deduzir_icms_desonerado)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.somar_ipi_base_difal_fcp)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.tipo_base_dupla)
                .HasColumnType("int");

            builder.Property(e => e.utiliza_lucro_base_icms)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.utiliza_lucro_base_pis)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.utiliza_lucro_base_cofins)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.codigo_ws)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.aliquota_diferimento_icms)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aliquota_diferimento_fcp)
                .HasColumnType("decimal(10,2)");
        }
    }
}
