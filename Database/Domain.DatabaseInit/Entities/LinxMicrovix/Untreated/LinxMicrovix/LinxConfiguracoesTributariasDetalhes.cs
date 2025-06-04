using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxConfiguracoesTributariasDetalhes", Schema = "untreated")]
    public class LinxConfiguracoesTributariasDetalhes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_config_tributaria { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? desc_classe_fiscal { get; private set; }

        [Column(TypeName = "char(10)")]
        public string? cod_natureza_operacao { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? desc_natureza_operacao { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? cfop_fiscal { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? desc_cfop_fiscal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_tributado_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_pis { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_cofins { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_reducao_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_reducao_icms_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? margem_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_st { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? margem_st_simulador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_st_simulador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_icms { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_icms_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? desc_cst_icms_fiscal { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_ipi_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? desc_cst_ipi_fiscal { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_pis_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? desc_cst_pis_fiscal { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cst_cofins_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? desc_cst_cofins_fiscal { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? desc_obs_padrao { get; private set; }

        [Column(TypeName = "bit")]
        public string? icms_credito { get; private set; }

        [Column(TypeName = "bit")]
        public string? ipi_credito { get; private set; }

        [Column(TypeName = "char(3)")]
        public string? cod_enquadramento_ipi { get; private set; }

        [Column(TypeName = "varchar(600)")]
        public string? desc_enquadramento_ipi { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_aliquota_interna_uf_destinatario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_aliquota_interestadual_uf_envolvidas { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? csosn_fiscal { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? desc_csosn_fiscal { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? forma_tributacao_pis { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? forma_tributacao_cofins { get; private set; }

        [Column(TypeName = "int")]
        public string? id_ramo_atividade { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "bit")]
        public string? usa_base_icms_para_calculo_st { get; private set; }

        [Column(TypeName = "int")]
        public string? id_classe_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cfop_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_icms_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_ipi_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_pis_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_cofins_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_obs { get; private set; }

        [Column(TypeName = "bit")]
        public string? tributado { get; private set; }

        [Column(TypeName = "bit")]
        public string? retido { get; private set; }

        [Column(TypeName = "int")]
        public string? icms_base_naotributado { get; private set; }

        [Column(TypeName = "int")]
        public string? ipi_base_naotributado { get; private set; }

        [Column(TypeName = "int")]
        public string? id_csosn_fiscal { get; private set; }

        [Column(TypeName = "bit")]
        public string? somar_icms_st { get; private set; }

        [Column(TypeName = "int")]
        public string? id_sped_tipo_base_credito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_pis_servico { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_cofins_servico { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_pis_fiscal_servico { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cst_cofins_fiscal_servico { get; private set; }

        [Column(TypeName = "bit")]
        public string? csrf { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? codigo_retencao_csrf { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_pis_csrf { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_cofins_csrf { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_csll_csrf { get; private set; }

        [Column(TypeName = "int")]
        public string? id_sped_tipo_base_credito_servico { get; private set; }

        [Column(TypeName = "bit")]
        public string? receita { get; private set; }

        [Column(TypeName = "bit")]
        public string? fci_informa_parcela_importada { get; private set; }

        [Column(TypeName = "bit")]
        public string? fci_informa_numero { get; private set; }

        [Column(TypeName = "bit")]
        public string? fci_informa_conteudo_importacao { get; private set; }

        [Column(TypeName = "bit")]
        public string? fci_informa_valor_importacao { get; private set; }

        [Column(TypeName = "int")]
        public string? iss_tipo_tributacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_margem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_aliquota { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_st_antecipado_percentual_reducao { get; private set; }

        [Column(TypeName = "bit")]
        public string? icms_st_antecipado_valor_integra_custo_medio { get; private set; }

        [Column(TypeName = "int")]
        public string? id_enquadramento_ipi { get; private set; }

        [Column(TypeName = "bit")]
        public string? usa_regime_estimativa_simplifica { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_carga_tributaria_media { get; private set; }

        [Column(TypeName = "bit")]
        public string? fcp_integra_custo_medio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_fcp { get; private set; }

        [Column(TypeName = "bit")]
        public string? fcp_credito { get; private set; }

        [Column(TypeName = "bit")]
        public string? fcp_reducao_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_icms_efetivo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_reducao_icms_efetivo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? icms_fcp_st_antecipado_aliquota { get; private set; }

        [Column(TypeName = "bit")]
        public string? difal_base_dupla { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_desoneracao_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliq_desoneracao_fcp { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? cod_beneficio_fiscal { get; private set; }

        [Column(TypeName = "int")]
        public string? id_motivo_desoneracao_icms { get; private set; }

        [Column(TypeName = "bit")]
        public string? deduzir_icms_custo { get; private set; }

        [Column(TypeName = "bit")]
        public string? deduzir_icms_desonerado { get; private set; }

        [Column(TypeName = "bit")]
        public string? somar_ipi_base_difal_fcp { get; private set; }

        [Column(TypeName = "int")]
        public string? tipo_base_dupla { get; private set; }

        [Column(TypeName = "bit")]
        public string? utiliza_lucro_base_icms { get; private set; }

        [Column(TypeName = "bit")]
        public string? utiliza_lucro_base_pis { get; private set; }

        [Column(TypeName = "bit")]
        public string? utiliza_lucro_base_cofins { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_diferimento_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aliquota_diferimento_fcp { get; private set; }
    }
}
