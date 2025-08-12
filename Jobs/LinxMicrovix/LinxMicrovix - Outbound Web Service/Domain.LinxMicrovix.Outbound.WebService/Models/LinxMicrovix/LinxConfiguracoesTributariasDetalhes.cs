
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_config_tributaria { get; private set; }
        public string? desc_classe_fiscal { get; private set; }
        public string? cod_natureza_operacao { get; private set; }
        public string? desc_natureza_operacao { get; private set; }
        public string? cfop_fiscal { get; private set; }
        public string? desc_cfop_fiscal { get; private set; }
        public decimal? aliq_icms { get; private set; }
        public decimal? valor_tributado_icms { get; private set; }
        public decimal? aliq_pis { get; private set; }
        public decimal? aliq_cofins { get; private set; }
        public decimal? perc_reducao_icms { get; private set; }
        public decimal? perc_reducao_icms_st { get; private set; }
        public decimal? margem_st { get; private set; }
        public decimal? aliquota_st { get; private set; }
        public decimal? margem_st_simulador { get; private set; }
        public decimal? aliquota_st_simulador { get; private set; }
        public decimal? desconto_icms { get; private set; }
        public string? cst_icms_fiscal { get; private set; }
        public string? desc_cst_icms_fiscal { get; private set; }
        public string? cst_ipi_fiscal { get; private set; }
        public string? desc_cst_ipi_fiscal { get; private set; }
        public string? cst_pis_fiscal { get; private set; }
        public string? desc_cst_pis_fiscal { get; private set; }
        public string? cst_cofins_fiscal { get; private set; }
        public string? desc_cst_cofins_fiscal { get; private set; }
        public string? desc_obs_padrao { get; private set; }
        public bool? icms_credito { get; private set; }
        public bool? ipi_credito { get; private set; }
        public string? cod_enquadramento_ipi { get; private set; }
        public string? desc_enquadramento_ipi { get; private set; }
        public decimal? perc_aliquota_interna_uf_destinatario { get; private set; }
        public decimal? perc_aliquota_interestadual_uf_envolvidas { get; private set; }
        public string? csosn_fiscal { get; private set; }
        public string? desc_csosn_fiscal { get; private set; }
        public string? forma_tributacao_pis { get; private set; }
        public string? forma_tributacao_cofins { get; private set; }
        public Int32? id_ramo_atividade { get; private set; }
        public Int32? empresa { get; private set; }
        public bool? usa_base_icms_para_calculo_st { get; private set; }
        public Int32? id_classe_fiscal { get; private set; }
        public Int32? id_cfop_fiscal { get; private set; }
        public Int32? id_cst_icms_fiscal { get; private set; }
        public Int32? id_cst_ipi_fiscal { get; private set; }
        public Int32? id_cst_pis_fiscal { get; private set; }
        public Int32? id_cst_cofins_fiscal { get; private set; }
        public Int32? id_obs { get; private set; }
        public bool? tributado { get; private set; }
        public bool? retido { get; private set; }
        public Int32? icms_base_naotributado { get; private set; }
        public Int32? ipi_base_naotributado { get; private set; }
        public Int32? id_csosn_fiscal { get; private set; }
        public bool? somar_icms_st { get; private set; }
        public Int32? id_sped_tipo_base_credito { get; private set; }
        public decimal? aliq_pis_servico { get; private set; }
        public decimal? aliq_cofins_servico { get; private set; }
        public Int32? id_cst_pis_fiscal_servico { get; private set; }
        public Int32? id_cst_cofins_fiscal_servico { get; private set; }
        public bool? csrf { get; private set; }
        public string? codigo_retencao_csrf { get; private set; }
        public decimal? aliq_pis_csrf { get; private set; }
        public decimal? aliq_cofins_csrf { get; private set; }
        public decimal? aliq_csll_csrf { get; private set; }
        public Int32? id_sped_tipo_base_credito_servico { get; private set; }
        public bool? receita { get; private set; }
        public bool? fci_informa_parcela_importada { get; private set; }
        public bool? fci_informa_numero { get; private set; }
        public bool? fci_informa_conteudo_importacao { get; private set; }
        public bool? fci_informa_valor_importacao { get; private set; }
        public Int32? iss_tipo_tributacao { get; private set; }
        public decimal? icms_st_antecipado_margem { get; private set; }
        public decimal? icms_st_antecipado_aliquota { get; private set; }
        public decimal? icms_st_antecipado_percentual_reducao { get; private set; }
        public bool? icms_st_antecipado_valor_integra_custo_medio { get; private set; }
        public Int32? id_enquadramento_ipi { get; private set; }
        public bool? usa_regime_estimativa_simplifica { get; private set; }
        public decimal? aliq_carga_tributaria_media { get; private set; }
        public bool? fcp_integra_custo_medio { get; private set; }
        public decimal? aliq_fcp { get; private set; }
        public bool? fcp_credito { get; private set; }
        public bool? fcp_reducao_icms { get; private set; }
        public decimal? aliq_icms_efetivo { get; private set; }
        public decimal? perc_reducao_icms_efetivo { get; private set; }
        public decimal? icms_fcp_st_antecipado_aliquota { get; private set; }
        public bool? difal_base_dupla { get; private set; }
        public decimal? aliq_desoneracao_icms { get; private set; }
        public decimal? aliq_desoneracao_fcp { get; private set; }
        public string? cod_beneficio_fiscal { get; private set; }
        public Int32? id_motivo_desoneracao_icms { get; private set; }
        public bool? deduzir_icms_custo { get; private set; }
        public bool? deduzir_icms_desonerado { get; private set; }
        public bool? somar_ipi_base_difal_fcp { get; private set; }
        public Int32? tipo_base_dupla { get; private set; }
        public bool? utiliza_lucro_base_icms { get; private set; }
        public bool? utiliza_lucro_base_pis { get; private set; }
        public bool? utiliza_lucro_base_cofins { get; private set; }
        public string? codigo_ws { get; private set; }
        public Int64? timestamp { get; private set; }
        public decimal? aliquota_diferimento_icms { get; private set; }
        public decimal? aliquota_diferimento_fcp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxConfiguracoesTributariasDetalhes() { }

        public LinxConfiguracoesTributariasDetalhes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxConfiguracoesTributariasDetalhes record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_config_tributaria = CustomConvertersExtensions.ConvertToInt32Validation(record.id_config_tributaria);
            this.id_ramo_atividade = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ramo_atividade);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_classe_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_classe_fiscal);
            this.id_cfop_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cfop_fiscal);
            this.id_cst_icms_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_icms_fiscal);
            this.id_cst_ipi_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_ipi_fiscal);
            this.id_cst_pis_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_pis_fiscal);
            this.id_cst_cofins_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_cofins_fiscal);
            this.id_obs = CustomConvertersExtensions.ConvertToInt32Validation(record.id_obs);
            this.icms_base_naotributado = CustomConvertersExtensions.ConvertToInt32Validation(record.icms_base_naotributado);
            this.ipi_base_naotributado = CustomConvertersExtensions.ConvertToInt32Validation(record.ipi_base_naotributado);
            this.id_csosn_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_csosn_fiscal);
            this.id_sped_tipo_base_credito = CustomConvertersExtensions.ConvertToInt32Validation(record.id_sped_tipo_base_credito);
            this.id_cst_pis_fiscal_servico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_pis_fiscal_servico);
            this.id_cst_cofins_fiscal_servico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_cofins_fiscal_servico);
            this.id_sped_tipo_base_credito_servico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_sped_tipo_base_credito_servico);
            this.iss_tipo_tributacao = CustomConvertersExtensions.ConvertToInt32Validation(record.iss_tipo_tributacao);
            this.id_enquadramento_ipi = CustomConvertersExtensions.ConvertToInt32Validation(record.id_enquadramento_ipi);
            this.id_motivo_desoneracao_icms = CustomConvertersExtensions.ConvertToInt32Validation(record.id_motivo_desoneracao_icms);
            this.tipo_base_dupla = CustomConvertersExtensions.ConvertToInt32Validation(record.tipo_base_dupla);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.aliq_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_icms);
            this.valor_tributado_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_tributado_icms);
            this.aliq_pis = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_pis);
            this.aliq_cofins = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_cofins);
            this.perc_reducao_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_reducao_icms);
            this.perc_reducao_icms_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_reducao_icms_st);
            this.margem_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.margem_st);
            this.aliquota_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliquota_st);
            this.margem_st_simulador = CustomConvertersExtensions.ConvertToDecimalValidation(record.margem_st_simulador);
            this.aliquota_st_simulador = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliquota_st_simulador);
            this.desconto_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto_icms);
            this.perc_aliquota_interna_uf_destinatario = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_aliquota_interna_uf_destinatario);
            this.perc_aliquota_interestadual_uf_envolvidas = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_aliquota_interestadual_uf_envolvidas);
            this.aliq_pis_servico = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_pis_servico);
            this.aliq_cofins_servico = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_cofins_servico);
            this.aliq_pis_csrf = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_pis_csrf);
            this.aliq_cofins_csrf = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_cofins_csrf);
            this.aliq_csll_csrf = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_csll_csrf);
            this.icms_st_antecipado_margem = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_antecipado_margem);
            this.icms_st_antecipado_aliquota = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_antecipado_aliquota);
            this.icms_st_antecipado_percentual_reducao = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_antecipado_percentual_reducao);
            this.aliq_carga_tributaria_media = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_carga_tributaria_media);
            this.aliq_fcp = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_fcp);
            this.aliq_icms_efetivo = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_icms_efetivo);
            this.perc_reducao_icms_efetivo = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_reducao_icms_efetivo);
            this.icms_fcp_st_antecipado_aliquota = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_fcp_st_antecipado_aliquota);
            this.aliq_desoneracao_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_desoneracao_icms);
            this.aliq_desoneracao_fcp = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_desoneracao_fcp);
            this.aliquota_diferimento_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliquota_diferimento_icms);
            this.aliquota_diferimento_fcp = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliquota_diferimento_fcp);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.icms_credito = CustomConvertersExtensions.ConvertToBooleanValidation(record.icms_credito);
            this.ipi_credito = CustomConvertersExtensions.ConvertToBooleanValidation(record.ipi_credito);
            this.usa_base_icms_para_calculo_st = CustomConvertersExtensions.ConvertToBooleanValidation(record.usa_base_icms_para_calculo_st);
            this.tributado = CustomConvertersExtensions.ConvertToBooleanValidation(record.tributado);
            this.retido = CustomConvertersExtensions.ConvertToBooleanValidation(record.retido);
            this.somar_icms_st = CustomConvertersExtensions.ConvertToBooleanValidation(record.somar_icms_st);
            this.csrf = CustomConvertersExtensions.ConvertToBooleanValidation(record.csrf);
            this.receita = CustomConvertersExtensions.ConvertToBooleanValidation(record.receita);
            this.fci_informa_parcela_importada = CustomConvertersExtensions.ConvertToBooleanValidation(record.fci_informa_parcela_importada);
            this.fci_informa_numero = CustomConvertersExtensions.ConvertToBooleanValidation(record.fci_informa_numero);
            this.fci_informa_conteudo_importacao = CustomConvertersExtensions.ConvertToBooleanValidation(record.fci_informa_conteudo_importacao);
            this.fci_informa_valor_importacao = CustomConvertersExtensions.ConvertToBooleanValidation(record.fci_informa_valor_importacao);
            this.icms_st_antecipado_valor_integra_custo_medio = CustomConvertersExtensions.ConvertToBooleanValidation(record.icms_st_antecipado_valor_integra_custo_medio);
            this.usa_regime_estimativa_simplifica = CustomConvertersExtensions.ConvertToBooleanValidation(record.usa_regime_estimativa_simplifica);
            this.fcp_integra_custo_medio = CustomConvertersExtensions.ConvertToBooleanValidation(record.fcp_integra_custo_medio);
            this.fcp_credito = CustomConvertersExtensions.ConvertToBooleanValidation(record.fcp_credito);
            this.fcp_reducao_icms = CustomConvertersExtensions.ConvertToBooleanValidation(record.fcp_reducao_icms);
            this.difal_base_dupla = CustomConvertersExtensions.ConvertToBooleanValidation(record.difal_base_dupla);
            this.deduzir_icms_custo = CustomConvertersExtensions.ConvertToBooleanValidation(record.deduzir_icms_custo);
            this.deduzir_icms_desonerado = CustomConvertersExtensions.ConvertToBooleanValidation(record.deduzir_icms_desonerado);
            this.somar_ipi_base_difal_fcp = CustomConvertersExtensions.ConvertToBooleanValidation(record.somar_ipi_base_difal_fcp);
            this.utiliza_lucro_base_icms = CustomConvertersExtensions.ConvertToBooleanValidation(record.utiliza_lucro_base_icms);
            this.utiliza_lucro_base_pis = CustomConvertersExtensions.ConvertToBooleanValidation(record.utiliza_lucro_base_pis);
            this.utiliza_lucro_base_cofins = CustomConvertersExtensions.ConvertToBooleanValidation(record.utiliza_lucro_base_cofins);
            this.cnpj_emp = record.cnpj_emp;
            this.desc_classe_fiscal = record.desc_classe_fiscal;
            this.cod_natureza_operacao = record.cod_natureza_operacao;
            this.desc_natureza_operacao = record.desc_natureza_operacao;
            this.cfop_fiscal = record.cfop_fiscal;
            this.desc_cfop_fiscal = record.desc_cfop_fiscal;
            this.cst_icms_fiscal = record.cst_icms_fiscal;
            this.desc_cst_icms_fiscal = record.desc_cst_icms_fiscal;
            this.cst_ipi_fiscal = record.cst_ipi_fiscal;
            this.desc_cst_ipi_fiscal = record.desc_cst_ipi_fiscal;
            this.cst_pis_fiscal = record.cst_pis_fiscal;
            this.desc_cst_pis_fiscal = record.desc_cst_pis_fiscal;
            this.cst_cofins_fiscal = record.cst_cofins_fiscal;
            this.desc_cst_cofins_fiscal = record.desc_cst_cofins_fiscal;
            this.desc_obs_padrao = record.desc_obs_padrao;
            this.cod_enquadramento_ipi = record.cod_enquadramento_ipi;
            this.desc_enquadramento_ipi = record.desc_enquadramento_ipi;
            this.csosn_fiscal = record.csosn_fiscal;
            this.desc_csosn_fiscal = record.desc_csosn_fiscal;
            this.forma_tributacao_pis = record.forma_tributacao_pis;
            this.forma_tributacao_cofins = record.forma_tributacao_cofins;
            this.codigo_retencao_csrf = record.codigo_retencao_csrf;
            this.cod_beneficio_fiscal = record.cod_beneficio_fiscal;
            this.codigo_ws = record.codigo_ws;
        }
    }
}
