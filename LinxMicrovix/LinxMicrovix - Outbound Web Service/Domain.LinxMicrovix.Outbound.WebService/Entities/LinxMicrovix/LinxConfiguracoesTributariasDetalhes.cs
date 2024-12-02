using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }
        
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_config_tributaria { get; private set; }
        
        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "desc_classe_fiscal")]
        public string? desc_classe_fiscal { get; private set; }
        
        [Column(TypeName = "char(10)")]
        [LengthValidation(length: 10, propertyName: "cod_natureza_operacao")]
        public string? cod_natureza_operacao { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "desc_natureza_operacao")]
        public string? desc_natureza_operacao { get; private set; }
        
        [Column(TypeName = "varchar(5)")]
        [LengthValidation(length: 5, propertyName: "cfop_fiscal")]
        public string? cfop_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(300)")]
        [LengthValidation(length: 300, propertyName: "desc_cfop_fiscal")]
        public string? desc_cfop_fiscal { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_icms { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_tributado_icms { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_pis { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_cofins { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? perc_reducao_icms { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? perc_reducao_icms_st { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? margem_st { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliquota_st { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? margem_st_simulador { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliquota_st_simulador { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto_icms { get; private set; }
        
        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "cst_icms_fiscal")]
        public string? cst_icms_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "desc_cst_icms_fiscal")]
        public string? desc_cst_icms_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "cst_ipi_fiscal")]
        public string? cst_ipi_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "desc_cst_ipi_fiscal")]
        public string? desc_cst_ipi_fiscal { get; private set; }

        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "cst_pis_fiscal")]
        public string? cst_pis_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "desc_cst_pis_fiscal")]
        public string? desc_cst_pis_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "cst_cofins_fiscal")]
        public string? cst_cofins_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "desc_cst_cofins_fiscal")]
        public string? desc_cst_cofins_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "desc_obs_padrao")]
        public string? desc_obs_padrao { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? icms_credito { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? ipi_credito { get; private set; }
        
        [Column(TypeName = "char(3)")]
        [LengthValidation(length: 3, propertyName: "cod_enquadramento_ipi")]
        public string? cod_enquadramento_ipi { get; private set; }
        
        [Column(TypeName = "varchar(600)")]
        [LengthValidation(length: 600, propertyName: "desc_enquadramento_ipi")]
        public string? desc_enquadramento_ipi { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? perc_aliquota_interna_uf_destinatario { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? perc_aliquota_interestadual_uf_envolvidas { get; private set; }
        
        [Column(TypeName = "varchar(5)")]
        [LengthValidation(length: 5, propertyName: "csosn_fiscal")]
        public string? csosn_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(200)")]
        [LengthValidation(length: 200, propertyName: "desc_csosn_fiscal")]
        public string? desc_csosn_fiscal { get; private set; }
        
        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "forma_tributacao_pis")]
        public string? forma_tributacao_pis { get; private set; }
        
        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "forma_tributacao_cofins")]
        public string? forma_tributacao_cofins { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_ramo_atividade { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? usa_base_icms_para_calculo_st { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_classe_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cfop_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cst_icms_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cst_ipi_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cst_pis_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cst_cofins_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_obs { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? tributado { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? retido { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? icms_base_naotributado { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? ipi_base_naotributado { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_csosn_fiscal { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? somar_icms_st { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_sped_tipo_base_credito { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_pis_servico { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_cofins_servico { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cst_pis_fiscal_servico { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_cst_cofins_fiscal_servico { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? csrf { get; private set; }
        
        [Column(TypeName = "varchar(4)")]
        [LengthValidation(length: 4, propertyName: "codigo_retencao_csrf")]
        public string? codigo_retencao_csrf { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_pis_csrf { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_cofins_csrf { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_csll_csrf { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_sped_tipo_base_credito_servico { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? receita { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fci_informa_parcela_importada { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fci_informa_numero { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fci_informa_conteudo_importacao { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fci_informa_valor_importacao { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? iss_tipo_tributacao { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? icms_st_antecipado_margem { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? icms_st_antecipado_aliquota { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? icms_st_antecipado_percentual_reducao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? icms_st_antecipado_valor_integra_custo_medio { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_enquadramento_ipi { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? usa_regime_estimativa_simplifica { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_carga_tributaria_media { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fcp_integra_custo_medio { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_fcp { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fcp_credito { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? fcp_reducao_icms { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_icms_efetivo { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? perc_reducao_icms_efetivo { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? icms_fcp_st_antecipado_aliquota { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? difal_base_dupla { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_desoneracao_icms { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliq_desoneracao_fcp { get; private set; }
        
        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "cod_beneficio_fiscal")]
        public string? cod_beneficio_fiscal { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_motivo_desoneracao_icms { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? deduzir_icms_custo { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? deduzir_icms_desonerado { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? somar_ipi_base_difal_fcp { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? tipo_base_dupla { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? utiliza_lucro_base_icms { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? utiliza_lucro_base_pis { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? utiliza_lucro_base_cofins { get; private set; }
        
        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliquota_diferimento_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? aliquota_diferimento_fcp { get; private set; }

        public LinxConfiguracoesTributariasDetalhes() { }

        public LinxConfiguracoesTributariasDetalhes(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_config_tributaria,
            string? desc_classe_fiscal,
            string? cod_natureza_operacao,
            string? desc_natureza_operacao,
            string? cfop_fiscal,
            string? desc_cfop_fiscal,
            string? aliq_icms,
            string? valor_tributado_icms,
            string? aliq_pis,
            string? aliq_cofins,
            string? perc_reducao_icms,
            string? perc_reducao_icms_st,
            string? margem_st,
            string? aliquota_st,
            string? margem_st_simulador,
            string? aliquota_st_simulador,
            string? desconto_icms,
            string? cst_icms_fiscal,
            string? desc_cst_icms_fiscal,
            string? cst_ipi_fiscal,
            string? desc_cst_ipi_fiscal,
            string? cst_pis_fiscal,
            string? desc_cst_pis_fiscal,
            string? cst_cofins_fiscal,
            string? desc_cst_cofins_fiscal,
            string? desc_obs_padrao,
            string? icms_credito,
            string? ipi_credito,
            string? cod_enquadramento_ipi,
            string? desc_enquadramento_ipi,
            string? perc_aliquota_interna_uf_destinatario,
            string? perc_aliquota_interestadual_uf_envolvidas,
            string? csosn_fiscal,
            string? desc_csosn_fiscal,
            string? forma_tributacao_pis,
            string? forma_tributacao_cofins,
            string? id_ramo_atividade,
            string? empresa,
            string? usa_base_icms_para_calculo_st,
            string? id_classe_fiscal,
            string? id_cfop_fiscal,
            string? id_cst_icms_fiscal,
            string? id_cst_ipi_fiscal,
            string? id_cst_pis_fiscal,
            string? id_cst_cofins_fiscal,
            string? id_obs,
            string? tributado,
            string? retido,
            string? icms_base_naotributado,
            string? ipi_base_naotributado,
            string? id_csosn_fiscal,
            string? somar_icms_st,
            string? id_sped_tipo_base_credito,
            string? aliq_pis_servico,
            string? aliq_cofins_servico,
            string? id_cst_pis_fiscal_servico,
            string? id_cst_cofins_fiscal_servico,
            string? csrf,
            string? codigo_retencao_csrf,
            string? aliq_pis_csrf,
            string? aliq_cofins_csrf,
            string? aliq_csll_csrf,
            string? id_sped_tipo_base_credito_servico,
            string? receita,
            string? fci_informa_parcela_importada,
            string? fci_informa_numero,
            string? fci_informa_conteudo_importacao,
            string? fci_informa_valor_importacao,
            string? iss_tipo_tributacao,
            string? icms_st_antecipado_margem,
            string? icms_st_antecipado_aliquota,
            string? icms_st_antecipado_percentual_reducao,
            string? icms_st_antecipado_valor_integra_custo_medio,
            string? id_enquadramento_ipi,
            string? usa_regime_estimativa_simplifica,
            string? aliq_carga_tributaria_media,
            string? fcp_integra_custo_medio,
            string? aliq_fcp,
            string? fcp_credito,
            string? fcp_reducao_icms,
            string? aliq_icms_efetivo,
            string? perc_reducao_icms_efetivo,
            string? icms_fcp_st_antecipado_aliquota,
            string? difal_base_dupla,
            string? aliq_desoneracao_icms,
            string? aliq_desoneracao_fcp,
            string? cod_beneficio_fiscal,
            string? id_motivo_desoneracao_icms,
            string? deduzir_icms_custo,
            string? deduzir_icms_desonerado,
            string? somar_ipi_base_difal_fcp,
            string? tipo_base_dupla,
            string? utiliza_lucro_base_icms,
            string? utiliza_lucro_base_pis,
            string? utiliza_lucro_base_cofins,
            string? codigo_ws,
            string? timestamp,
            string? aliquota_diferimento_icms,
            string? aliquota_diferimento_fcp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_config_tributaria =
                ConvertToInt32Validation.IsValid(id_config_tributaria, "id_config_tributaria", listValidations) ?
                Convert.ToInt32(id_config_tributaria) :
                0;

            this.id_ramo_atividade =
                ConvertToInt32Validation.IsValid(id_ramo_atividade, "id_ramo_atividade", listValidations) ?
                Convert.ToInt32(id_ramo_atividade) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_classe_fiscal =
                ConvertToInt32Validation.IsValid(id_classe_fiscal, "id_classe_fiscal", listValidations) ?
                Convert.ToInt32(id_classe_fiscal) :
                0;

            this.id_cfop_fiscal =
                ConvertToInt32Validation.IsValid(id_cfop_fiscal, "id_cfop_fiscal", listValidations) ?
                Convert.ToInt32(id_cfop_fiscal) :
                0;

            this.id_cst_icms_fiscal =
                ConvertToInt32Validation.IsValid(id_cst_icms_fiscal, "id_cst_icms_fiscal", listValidations) ?
                Convert.ToInt32(id_cst_icms_fiscal) :
                0;

            this.id_cst_ipi_fiscal =
                ConvertToInt32Validation.IsValid(id_cst_ipi_fiscal, "id_cst_ipi_fiscal", listValidations) ?
                Convert.ToInt32(id_cst_ipi_fiscal) :
                0;

            this.id_cst_pis_fiscal =
                ConvertToInt32Validation.IsValid(id_cst_pis_fiscal, "id_cst_pis_fiscal", listValidations) ?
                Convert.ToInt32(id_cst_pis_fiscal) :
                0;

            this.id_cst_cofins_fiscal =
                ConvertToInt32Validation.IsValid(id_cst_cofins_fiscal, "id_cst_cofins_fiscal", listValidations) ?
                Convert.ToInt32(id_cst_cofins_fiscal) :
                0;

            this.id_obs =
                ConvertToInt32Validation.IsValid(id_obs, "id_obs", listValidations) ?
                Convert.ToInt32(id_obs) :
                0;

            this.icms_base_naotributado =
                ConvertToInt32Validation.IsValid(icms_base_naotributado, "icms_base_naotributado", listValidations) ?
                Convert.ToInt32(icms_base_naotributado) :
                0;

            this.ipi_base_naotributado =
                ConvertToInt32Validation.IsValid(ipi_base_naotributado, "ipi_base_naotributado", listValidations) ?
                Convert.ToInt32(ipi_base_naotributado) :
                0;

            this.id_csosn_fiscal =
                ConvertToInt32Validation.IsValid(id_csosn_fiscal, "id_csosn_fiscal", listValidations) ?
                Convert.ToInt32(id_csosn_fiscal) :
                0;

            this.id_sped_tipo_base_credito =
                ConvertToInt32Validation.IsValid(id_sped_tipo_base_credito, "id_sped_tipo_base_credito", listValidations) ?
                Convert.ToInt32(id_sped_tipo_base_credito) :
                0;

            this.id_cst_pis_fiscal_servico =
                ConvertToInt32Validation.IsValid(id_cst_pis_fiscal_servico, "id_cst_pis_fiscal_servico", listValidations) ?
                Convert.ToInt32(id_cst_pis_fiscal_servico) :
                0;

            this.id_cst_cofins_fiscal_servico =
                ConvertToInt32Validation.IsValid(id_cst_cofins_fiscal_servico, "id_cst_cofins_fiscal_servico", listValidations) ?
                Convert.ToInt32(id_cst_cofins_fiscal_servico) :
                0;

            this.id_sped_tipo_base_credito_servico =
                ConvertToInt32Validation.IsValid(id_sped_tipo_base_credito_servico, "id_sped_tipo_base_credito_servico", listValidations) ?
                Convert.ToInt32(id_sped_tipo_base_credito_servico) :
                0;

            this.iss_tipo_tributacao =
                ConvertToInt32Validation.IsValid(iss_tipo_tributacao, "iss_tipo_tributacao", listValidations) ?
                Convert.ToInt32(iss_tipo_tributacao) :
                0;

            this.id_enquadramento_ipi =
                ConvertToInt32Validation.IsValid(id_enquadramento_ipi, "id_enquadramento_ipi", listValidations) ?
                Convert.ToInt32(id_enquadramento_ipi) :
                0;

            this.id_motivo_desoneracao_icms =
                ConvertToInt32Validation.IsValid(id_motivo_desoneracao_icms, "id_motivo_desoneracao_icms", listValidations) ?
                Convert.ToInt32(id_motivo_desoneracao_icms) :
                0;

            this.tipo_base_dupla =
                ConvertToInt32Validation.IsValid(tipo_base_dupla, "tipo_base_dupla", listValidations) ?
                Convert.ToInt32(tipo_base_dupla) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.aliq_icms =
                ConvertToDecimalValidation.IsValid(aliq_icms, "aliq_icms", listValidations) ?
                Convert.ToDecimal(aliq_icms) :
                0;

            this.valor_tributado_icms =
                ConvertToDecimalValidation.IsValid(valor_tributado_icms, "valor_tributado_icms", listValidations) ?
                Convert.ToDecimal(valor_tributado_icms) :
                0;

            this.aliq_pis =
                ConvertToDecimalValidation.IsValid(aliq_pis, "aliq_pis", listValidations) ?
                Convert.ToDecimal(aliq_pis) :
                0;

            this.aliq_cofins =
                ConvertToDecimalValidation.IsValid(aliq_cofins, "aliq_cofins", listValidations) ?
                Convert.ToDecimal(aliq_cofins) :
                0;

            this.perc_reducao_icms =
                ConvertToDecimalValidation.IsValid(perc_reducao_icms, "perc_reducao_icms", listValidations) ?
                Convert.ToDecimal(perc_reducao_icms) :
                0;

            this.perc_reducao_icms_st =
                ConvertToDecimalValidation.IsValid(perc_reducao_icms_st, "perc_reducao_icms_st", listValidations) ?
                Convert.ToDecimal(perc_reducao_icms_st) :
                0;

            this.margem_st =
                ConvertToDecimalValidation.IsValid(margem_st, "margem_st", listValidations) ?
                Convert.ToDecimal(margem_st) :
                0;

            this.aliquota_st =
                ConvertToDecimalValidation.IsValid(aliquota_st, "aliquota_st", listValidations) ?
                Convert.ToDecimal(aliquota_st) :
                0;

            this.margem_st_simulador =
                ConvertToDecimalValidation.IsValid(margem_st_simulador, "margem_st_simulador", listValidations) ?
                Convert.ToDecimal(margem_st_simulador) :
                0;

            this.aliquota_st_simulador =
                ConvertToDecimalValidation.IsValid(aliquota_st_simulador, "aliquota_st_simulador", listValidations) ?
                Convert.ToDecimal(aliquota_st_simulador) :
                0;

            this.desconto_icms =
                ConvertToDecimalValidation.IsValid(desconto_icms, "desconto_icms", listValidations) ?
                Convert.ToDecimal(desconto_icms) :
                0;

            this.perc_aliquota_interna_uf_destinatario =
                ConvertToDecimalValidation.IsValid(perc_aliquota_interna_uf_destinatario, "perc_aliquota_interna_uf_destinatario", listValidations) ?
                Convert.ToDecimal(perc_aliquota_interna_uf_destinatario) :
                0;

            this.perc_aliquota_interestadual_uf_envolvidas =
                ConvertToDecimalValidation.IsValid(perc_aliquota_interestadual_uf_envolvidas, "perc_aliquota_interestadual_uf_envolvidas", listValidations) ?
                Convert.ToDecimal(perc_aliquota_interestadual_uf_envolvidas) :
                0;

            this.aliq_pis_servico =
                ConvertToDecimalValidation.IsValid(aliq_pis_servico, "aliq_pis_servico", listValidations) ?
                Convert.ToDecimal(aliq_pis_servico) :
                0;

            this.aliq_cofins_servico =
                ConvertToDecimalValidation.IsValid(aliq_cofins_servico, "aliq_cofins_servico", listValidations) ?
                Convert.ToDecimal(aliq_cofins_servico) :
                0;

            this.aliq_pis_csrf =
                ConvertToDecimalValidation.IsValid(aliq_pis_csrf, "aliq_pis_csrf", listValidations) ?
                Convert.ToDecimal(aliq_pis_csrf) :
                0;

            this.aliq_cofins_csrf =
                ConvertToDecimalValidation.IsValid(aliq_cofins_csrf, "aliq_cofins_csrf", listValidations) ?
                Convert.ToDecimal(aliq_cofins_csrf) :
                0;

            this.aliq_csll_csrf =
                ConvertToDecimalValidation.IsValid(aliq_csll_csrf, "aliq_csll_csrf", listValidations) ?
                Convert.ToDecimal(aliq_csll_csrf) :
                0;

            this.icms_st_antecipado_margem =
                ConvertToDecimalValidation.IsValid(icms_st_antecipado_margem, "icms_st_antecipado_margem", listValidations) ?
                Convert.ToDecimal(icms_st_antecipado_margem) :
                0;

            this.icms_st_antecipado_aliquota =
                ConvertToDecimalValidation.IsValid(icms_st_antecipado_aliquota, "icms_st_antecipado_aliquota", listValidations) ?
                Convert.ToDecimal(icms_st_antecipado_aliquota) :
                0;

            this.icms_st_antecipado_percentual_reducao =
                ConvertToDecimalValidation.IsValid(icms_st_antecipado_percentual_reducao, "icms_st_antecipado_percentual_reducao", listValidations) ?
                Convert.ToDecimal(icms_st_antecipado_percentual_reducao) :
                0;

            this.aliq_carga_tributaria_media =
                ConvertToDecimalValidation.IsValid(aliq_carga_tributaria_media, "aliq_carga_tributaria_media", listValidations) ?
                Convert.ToDecimal(aliq_carga_tributaria_media) :
                0;

            this.aliq_fcp =
                ConvertToDecimalValidation.IsValid(aliq_fcp, "aliq_fcp", listValidations) ?
                Convert.ToDecimal(aliq_fcp) :
                0;

            this.aliq_icms_efetivo =
                ConvertToDecimalValidation.IsValid(aliq_icms_efetivo, "aliq_icms_efetivo", listValidations) ?
                Convert.ToDecimal(aliq_icms_efetivo) :
                0;

            this.perc_reducao_icms_efetivo =
                ConvertToDecimalValidation.IsValid(perc_reducao_icms_efetivo, "perc_reducao_icms_efetivo", listValidations) ?
                Convert.ToDecimal(perc_reducao_icms_efetivo) :
                0;

            this.icms_fcp_st_antecipado_aliquota =
                ConvertToDecimalValidation.IsValid(icms_fcp_st_antecipado_aliquota, "icms_fcp_st_antecipado_aliquota", listValidations) ?
                Convert.ToDecimal(icms_fcp_st_antecipado_aliquota) :
                0;

            this.aliq_desoneracao_icms =
                ConvertToDecimalValidation.IsValid(aliq_desoneracao_icms, "aliq_desoneracao_icms", listValidations) ?
                Convert.ToDecimal(aliq_desoneracao_icms) :
                0;

            this.aliq_desoneracao_fcp =
                ConvertToDecimalValidation.IsValid(aliq_desoneracao_fcp, "aliq_desoneracao_fcp", listValidations) ?
                Convert.ToDecimal(aliq_desoneracao_fcp) :
                0;

            this.aliquota_diferimento_icms =
                ConvertToDecimalValidation.IsValid(aliquota_diferimento_icms, "aliquota_diferimento_icms", listValidations) ?
                Convert.ToDecimal(aliquota_diferimento_icms) :
                0;

            this.aliquota_diferimento_fcp =
                ConvertToDecimalValidation.IsValid(aliquota_diferimento_fcp, "aliquota_diferimento_fcp", listValidations) ?
                Convert.ToDecimal(aliquota_diferimento_fcp) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.icms_credito =
                ConvertToBooleanValidation.IsValid(icms_credito, "icms_credito", listValidations) ?
                Convert.ToBoolean(icms_credito) :
                false;

            this.ipi_credito =
                ConvertToBooleanValidation.IsValid(ipi_credito, "ipi_credito", listValidations) ?
                Convert.ToBoolean(ipi_credito) :
                false;

            this.usa_base_icms_para_calculo_st =
                ConvertToBooleanValidation.IsValid(usa_base_icms_para_calculo_st, "usa_base_icms_para_calculo_st", listValidations) ?
                Convert.ToBoolean(usa_base_icms_para_calculo_st) :
                false;

            this.tributado =
                ConvertToBooleanValidation.IsValid(tributado, "tributado", listValidations) ?
                Convert.ToBoolean(tributado) :
                false;

            this.retido =
                ConvertToBooleanValidation.IsValid(retido, "retido", listValidations) ?
                Convert.ToBoolean(retido) :
                false;

            this.somar_icms_st =
                ConvertToBooleanValidation.IsValid(somar_icms_st, "somar_icms_st", listValidations) ?
                Convert.ToBoolean(somar_icms_st) :
                false;

            this.csrf =
                ConvertToBooleanValidation.IsValid(csrf, "csrf", listValidations) ?
                Convert.ToBoolean(csrf) :
                false;

            this.receita =
                ConvertToBooleanValidation.IsValid(receita, "receita", listValidations) ?
                Convert.ToBoolean(receita) :
                false;

            this.fci_informa_parcela_importada =
                ConvertToBooleanValidation.IsValid(fci_informa_parcela_importada, "fci_informa_parcela_importada", listValidations) ?
                Convert.ToBoolean(fci_informa_parcela_importada) :
                false;

            this.fci_informa_numero =
                ConvertToBooleanValidation.IsValid(fci_informa_numero, "fci_informa_numero", listValidations) ?
                Convert.ToBoolean(fci_informa_numero) :
                false;

            this.fci_informa_conteudo_importacao =
                ConvertToBooleanValidation.IsValid(fci_informa_conteudo_importacao, "fci_informa_conteudo_importacao", listValidations) ?
                Convert.ToBoolean(fci_informa_conteudo_importacao) :
                false;

            this.fci_informa_valor_importacao =
                ConvertToBooleanValidation.IsValid(fci_informa_valor_importacao, "fci_informa_valor_importacao", listValidations) ?
                Convert.ToBoolean(fci_informa_valor_importacao) :
                false;

            this.icms_st_antecipado_valor_integra_custo_medio =
                ConvertToBooleanValidation.IsValid(icms_st_antecipado_valor_integra_custo_medio, "icms_st_antecipado_valor_integra_custo_medio", listValidations) ?
                Convert.ToBoolean(icms_st_antecipado_valor_integra_custo_medio) :
                false;

            this.usa_regime_estimativa_simplifica =
                ConvertToBooleanValidation.IsValid(usa_regime_estimativa_simplifica, "usa_regime_estimativa_simplifica", listValidations) ?
                Convert.ToBoolean(usa_regime_estimativa_simplifica) :
                false;

            this.fcp_integra_custo_medio =
                ConvertToBooleanValidation.IsValid(fcp_integra_custo_medio, "fcp_integra_custo_medio", listValidations) ?
                Convert.ToBoolean(fcp_integra_custo_medio) :
                false;

            this.fcp_credito =
                ConvertToBooleanValidation.IsValid(fcp_credito, "fcp_credito", listValidations) ?
                Convert.ToBoolean(fcp_credito) :
                false;

            this.fcp_reducao_icms =
                ConvertToBooleanValidation.IsValid(fcp_reducao_icms, "fcp_reducao_icms", listValidations) ?
                Convert.ToBoolean(fcp_reducao_icms) :
                false;

            this.difal_base_dupla =
                ConvertToBooleanValidation.IsValid(difal_base_dupla, "difal_base_dupla", listValidations) ?
                Convert.ToBoolean(difal_base_dupla) :
                false;

            this.deduzir_icms_custo =
                ConvertToBooleanValidation.IsValid(deduzir_icms_custo, "deduzir_icms_custo", listValidations) ?
                Convert.ToBoolean(deduzir_icms_custo) :
                false;

            this.deduzir_icms_desonerado =
                ConvertToBooleanValidation.IsValid(deduzir_icms_desonerado, "deduzir_icms_desonerado", listValidations) ?
                Convert.ToBoolean(deduzir_icms_desonerado) :
                false;

            this.somar_ipi_base_difal_fcp =
                ConvertToBooleanValidation.IsValid(somar_ipi_base_difal_fcp, "somar_ipi_base_difal_fcp", listValidations) ?
                Convert.ToBoolean(somar_ipi_base_difal_fcp) :
                false;

            this.utiliza_lucro_base_icms =
                ConvertToBooleanValidation.IsValid(utiliza_lucro_base_icms, "utiliza_lucro_base_icms", listValidations) ?
                Convert.ToBoolean(utiliza_lucro_base_icms) :
                false;

            this.utiliza_lucro_base_pis =
                ConvertToBooleanValidation.IsValid(utiliza_lucro_base_pis, "utiliza_lucro_base_pis", listValidations) ?
                Convert.ToBoolean(utiliza_lucro_base_pis) :
                false;

            this.utiliza_lucro_base_cofins =
                ConvertToBooleanValidation.IsValid(utiliza_lucro_base_cofins, "utiliza_lucro_base_cofins", listValidations) ?
                Convert.ToBoolean(utiliza_lucro_base_cofins) :
                false;

            this.cnpj_emp = cnpj_emp;
            this.desc_classe_fiscal = desc_classe_fiscal;
            this.cod_natureza_operacao = cod_natureza_operacao;
            this.desc_natureza_operacao = desc_natureza_operacao;
            this.cfop_fiscal = cfop_fiscal;
            this.desc_cfop_fiscal = desc_cfop_fiscal;
            this.cst_icms_fiscal = cst_icms_fiscal;
            this.desc_cst_icms_fiscal = desc_cst_icms_fiscal;
            this.cst_ipi_fiscal = cst_ipi_fiscal;
            this.desc_cst_ipi_fiscal = desc_cst_ipi_fiscal;
            this.cst_pis_fiscal = cst_pis_fiscal;
            this.desc_cst_pis_fiscal = desc_cst_pis_fiscal;
            this.cst_cofins_fiscal = cst_cofins_fiscal;
            this.desc_cst_cofins_fiscal = desc_cst_cofins_fiscal;
            this.desc_obs_padrao = desc_obs_padrao;
            this.cod_enquadramento_ipi = cod_enquadramento_ipi;
            this.desc_enquadramento_ipi = desc_enquadramento_ipi;
            this.csosn_fiscal = csosn_fiscal;
            this.desc_csosn_fiscal = desc_csosn_fiscal;
            this.forma_tributacao_pis = forma_tributacao_pis;
            this.forma_tributacao_cofins = forma_tributacao_cofins;
            this.codigo_retencao_csrf = codigo_retencao_csrf;
            this.cod_beneficio_fiscal = cod_beneficio_fiscal;
            this.codigo_ws = codigo_ws;
        }
    }
}
 