namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhes
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_config_tributaria { get; set; }
        public string? desc_classe_fiscal { get; set; }
        public string? cod_natureza_operacao { get; set; }
        public string? desc_natureza_operacao { get; set; }
        public string? cfop_fiscal { get; set; }
        public string? desc_cfop_fiscal { get; set; }
        public string? aliq_icms { get; set; }
        public string? valor_tributado_icms { get; set; }
        public string? aliq_pis { get; set; }
        public string? aliq_cofins { get; set; }
        public string? perc_reducao_icms { get; set; }
        public string? perc_reducao_icms_st { get; set; }
        public string? margem_st { get; set; }
        public string? aliquota_st { get; set; }
        public string? margem_st_simulador { get; set; }
        public string? aliquota_st_simulador { get; set; }
        public string? desconto_icms { get; set; }
        public string? cst_icms_fiscal { get; set; }
        public string? desc_cst_icms_fiscal { get; set; }
        public string? cst_ipi_fiscal { get; set; }
        public string? desc_cst_ipi_fiscal { get; set; }
        public string? cst_pis_fiscal { get; set; }
        public string? desc_cst_pis_fiscal { get; set; }
        public string? cst_cofins_fiscal { get; set; }
        public string? desc_cst_cofins_fiscal { get; set; }
        public string? desc_obs_padrao { get; set; }
        public string? icms_credito { get; set; }
        public string? ipi_credito { get; set; }
        public string? cod_enquadramento_ipi { get; set; }
        public string? desc_enquadramento_ipi { get; set; }
        public string? perc_aliquota_interna_uf_destinatario { get; set; }
        public string? perc_aliquota_interestadual_uf_envolvidas { get; set; }
        public string? csosn_fiscal { get; set; }
        public string? desc_csosn_fiscal { get; set; }
        public string? forma_tributacao_pis { get; set; }
        public string? forma_tributacao_cofins { get; set; }
        public string? id_ramo_atividade { get; set; }
        public string? empresa { get; set; }
        public string? usa_base_icms_para_calculo_st { get; set; }
        public string? id_classe_fiscal { get; set; }
        public string? id_cfop_fiscal { get; set; }
        public string? id_cst_icms_fiscal { get; set; }
        public string? id_cst_ipi_fiscal { get; set; }
        public string? id_cst_pis_fiscal { get; set; }
        public string? id_cst_cofins_fiscal { get; set; }
        public string? id_obs { get; set; }
        public string? tributado { get; set; }
        public string? retido { get; set; }
        public string? icms_base_naotributado { get; set; }
        public string? ipi_base_naotributado { get; set; }
        public string? id_csosn_fiscal { get; set; }
        public string? somar_icms_st { get; set; }
        public string? id_sped_tipo_base_credito { get; set; }
        public string? aliq_pis_servico { get; set; }
        public string? aliq_cofins_servico { get; set; }
        public string? id_cst_pis_fiscal_servico { get; set; }
        public string? id_cst_cofins_fiscal_servico { get; set; }
        public string? csrf { get; set; }
        public string? codigo_retencao_csrf { get; set; }
        public string? aliq_pis_csrf { get; set; }
        public string? aliq_cofins_csrf { get; set; }
        public string? aliq_csll_csrf { get; set; }
        public string? id_sped_tipo_base_credito_servico { get; set; }
        public string? receita { get; set; }
        public string? fci_informa_parcela_importada { get; set; }
        public string? fci_informa_numero { get; set; }
        public string? fci_informa_conteudo_importacao { get; set; }
        public string? fci_informa_valor_importacao { get; set; }
        public string? iss_tipo_tributacao { get; set; }
        public string? icms_st_antecipado_margem { get; set; }
        public string? icms_st_antecipado_aliquota { get; set; }
        public string? icms_st_antecipado_percentual_reducao { get; set; }
        public string? icms_st_antecipado_valor_integra_custo_medio { get; set; }
        public string? id_enquadramento_ipi { get; set; }
        public string? usa_regime_estimativa_simplifica { get; set; }
        public string? aliq_carga_tributaria_media { get; set; }
        public string? fcp_integra_custo_medio { get; set; }
        public string? aliq_fcp { get; set; }
        public string? fcp_credito { get; set; }
        public string? fcp_reducao_icms { get; set; }
        public string? aliq_icms_efetivo { get; set; }
        public string? perc_reducao_icms_efetivo { get; set; }
        public string? icms_fcp_st_antecipado_aliquota { get; set; }
        public string? difal_base_dupla { get; set; }
        public string? aliq_desoneracao_icms { get; set; }
        public string? aliq_desoneracao_fcp { get; set; }
        public string? cod_beneficio_fiscal { get; set; }
        public string? id_motivo_desoneracao_icms { get; set; }
        public string? deduzir_icms_custo { get; set; }
        public string? deduzir_icms_desonerado { get; set; }
        public string? somar_ipi_base_difal_fcp { get; set; }
        public string? tipo_base_dupla { get; set; }
        public string? utiliza_lucro_base_icms { get; set; }
        public string? utiliza_lucro_base_pis { get; set; }
        public string? utiliza_lucro_base_cofins { get; set; }
        public string? codigo_ws { get; set; }
        public string? timestamp { get; set; }
        public string? aliquota_diferimento_icms { get; set; }
        public string? aliquota_diferimento_fcp { get; set; }

        public LinxConfiguracoesTributariasDetalhes()
        {
        }

        public LinxConfiguracoesTributariasDetalhes(string? portal, string? cnpj_emp, string? id_config_tributaria, string? desc_classe_fiscal, string? cod_natureza_operacao, string? desc_natureza_operacao, string? cfop_fiscal, string? desc_cfop_fiscal, string? aliq_icms, string? valor_tributado_icms, string? aliq_pis, string? aliq_cofins, string? perc_reducao_icms, string? perc_reducao_icms_st, string? margem_st, string? aliquota_st, string? margem_st_simulador, string? aliquota_st_simulador, string? desconto_icms, string? cst_icms_fiscal, string? desc_cst_icms_fiscal, string? cst_ipi_fiscal, string? desc_cst_ipi_fiscal, string? cst_pis_fiscal, string? desc_cst_pis_fiscal, string? cst_cofins_fiscal, string? desc_cst_cofins_fiscal, string? desc_obs_padrao, string? icms_credito, string? ipi_credito, string? cod_enquadramento_ipi, string? desc_enquadramento_ipi, string? perc_aliquota_interna_uf_destinatario, string? perc_aliquota_interestadual_uf_envolvidas, string? csosn_fiscal, string? desc_csosn_fiscal, string? forma_tributacao_pis, string? forma_tributacao_cofins, string? id_ramo_atividade, string? empresa, string? usa_base_icms_para_calculo_st, string? id_classe_fiscal, string? id_cfop_fiscal, string? id_cst_icms_fiscal, string? id_cst_ipi_fiscal, string? id_cst_pis_fiscal, string? id_cst_cofins_fiscal, string? id_obs, string? tributado, string? retido, string? icms_base_naotributado, string? ipi_base_naotributado, string? id_csosn_fiscal, string? somar_icms_st, string? id_sped_tipo_base_credito, string? aliq_pis_servico, string? aliq_cofins_servico, string? id_cst_pis_fiscal_servico, string? id_cst_cofins_fiscal_servico, string? csrf, string? codigo_retencao_csrf, string? aliq_pis_csrf, string? aliq_cofins_csrf, string? aliq_csll_csrf, string? id_sped_tipo_base_credito_servico, string? receita, string? fci_informa_parcela_importada, string? fci_informa_numero, string? fci_informa_conteudo_importacao, string? fci_informa_valor_importacao, string? iss_tipo_tributacao, string? icms_st_antecipado_margem, string? icms_st_antecipado_aliquota, string? icms_st_antecipado_percentual_reducao, string? icms_st_antecipado_valor_integra_custo_medio, string? id_enquadramento_ipi, string? usa_regime_estimativa_simplifica, string? aliq_carga_tributaria_media, string? fcp_integra_custo_medio, string? aliq_fcp, string? fcp_credito, string? fcp_reducao_icms, string? aliq_icms_efetivo, string? perc_reducao_icms_efetivo, string? icms_fcp_st_antecipado_aliquota, string? difal_base_dupla, string? aliq_desoneracao_icms, string? aliq_desoneracao_fcp, string? cod_beneficio_fiscal, string? id_motivo_desoneracao_icms, string? deduzir_icms_custo, string? deduzir_icms_desonerado, string? somar_ipi_base_difal_fcp, string? tipo_base_dupla, string? utiliza_lucro_base_icms, string? utiliza_lucro_base_pis, string? utiliza_lucro_base_cofins, string? codigo_ws, string? timestamp, string? aliquota_diferimento_icms, string? aliquota_diferimento_fcp)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_config_tributaria = id_config_tributaria;
            this.desc_classe_fiscal = desc_classe_fiscal;
            this.cod_natureza_operacao = cod_natureza_operacao;
            this.desc_natureza_operacao = desc_natureza_operacao;
            this.cfop_fiscal = cfop_fiscal;
            this.desc_cfop_fiscal = desc_cfop_fiscal;
            this.aliq_icms = aliq_icms;
            this.valor_tributado_icms = valor_tributado_icms;
            this.aliq_pis = aliq_pis;
            this.aliq_cofins = aliq_cofins;
            this.perc_reducao_icms = perc_reducao_icms;
            this.perc_reducao_icms_st = perc_reducao_icms_st;
            this.margem_st = margem_st;
            this.aliquota_st = aliquota_st;
            this.margem_st_simulador = margem_st_simulador;
            this.aliquota_st_simulador = aliquota_st_simulador;
            this.desconto_icms = desconto_icms;
            this.cst_icms_fiscal = cst_icms_fiscal;
            this.desc_cst_icms_fiscal = desc_cst_icms_fiscal;
            this.cst_ipi_fiscal = cst_ipi_fiscal;
            this.desc_cst_ipi_fiscal = desc_cst_ipi_fiscal;
            this.cst_pis_fiscal = cst_pis_fiscal;
            this.desc_cst_pis_fiscal = desc_cst_pis_fiscal;
            this.cst_cofins_fiscal = cst_cofins_fiscal;
            this.desc_cst_cofins_fiscal = desc_cst_cofins_fiscal;
            this.desc_obs_padrao = desc_obs_padrao;
            this.icms_credito = icms_credito;
            this.ipi_credito = ipi_credito;
            this.cod_enquadramento_ipi = cod_enquadramento_ipi;
            this.desc_enquadramento_ipi = desc_enquadramento_ipi;
            this.perc_aliquota_interna_uf_destinatario = perc_aliquota_interna_uf_destinatario;
            this.perc_aliquota_interestadual_uf_envolvidas = perc_aliquota_interestadual_uf_envolvidas;
            this.csosn_fiscal = csosn_fiscal;
            this.desc_csosn_fiscal = desc_csosn_fiscal;
            this.forma_tributacao_pis = forma_tributacao_pis;
            this.forma_tributacao_cofins = forma_tributacao_cofins;
            this.id_ramo_atividade = id_ramo_atividade;
            this.empresa = empresa;
            this.usa_base_icms_para_calculo_st = usa_base_icms_para_calculo_st;
            this.id_classe_fiscal = id_classe_fiscal;
            this.id_cfop_fiscal = id_cfop_fiscal;
            this.id_cst_icms_fiscal = id_cst_icms_fiscal;
            this.id_cst_ipi_fiscal = id_cst_ipi_fiscal;
            this.id_cst_pis_fiscal = id_cst_pis_fiscal;
            this.id_cst_cofins_fiscal = id_cst_cofins_fiscal;
            this.id_obs = id_obs;
            this.tributado = tributado;
            this.retido = retido;
            this.icms_base_naotributado = icms_base_naotributado;
            this.ipi_base_naotributado = ipi_base_naotributado;
            this.id_csosn_fiscal = id_csosn_fiscal;
            this.somar_icms_st = somar_icms_st;
            this.id_sped_tipo_base_credito = id_sped_tipo_base_credito;
            this.aliq_pis_servico = aliq_pis_servico;
            this.aliq_cofins_servico = aliq_cofins_servico;
            this.id_cst_pis_fiscal_servico = id_cst_pis_fiscal_servico;
            this.id_cst_cofins_fiscal_servico = id_cst_cofins_fiscal_servico;
            this.csrf = csrf;
            this.codigo_retencao_csrf = codigo_retencao_csrf;
            this.aliq_pis_csrf = aliq_pis_csrf;
            this.aliq_cofins_csrf = aliq_cofins_csrf;
            this.aliq_csll_csrf = aliq_csll_csrf;
            this.id_sped_tipo_base_credito_servico = id_sped_tipo_base_credito_servico;
            this.receita = receita;
            this.fci_informa_parcela_importada = fci_informa_parcela_importada;
            this.fci_informa_numero = fci_informa_numero;
            this.fci_informa_conteudo_importacao = fci_informa_conteudo_importacao;
            this.fci_informa_valor_importacao = fci_informa_valor_importacao;
            this.iss_tipo_tributacao = iss_tipo_tributacao;
            this.icms_st_antecipado_margem = icms_st_antecipado_margem;
            this.icms_st_antecipado_aliquota = icms_st_antecipado_aliquota;
            this.icms_st_antecipado_percentual_reducao = icms_st_antecipado_percentual_reducao;
            this.icms_st_antecipado_valor_integra_custo_medio = icms_st_antecipado_valor_integra_custo_medio;
            this.id_enquadramento_ipi = id_enquadramento_ipi;
            this.usa_regime_estimativa_simplifica = usa_regime_estimativa_simplifica;
            this.aliq_carga_tributaria_media = aliq_carga_tributaria_media;
            this.fcp_integra_custo_medio = fcp_integra_custo_medio;
            this.aliq_fcp = aliq_fcp;
            this.fcp_credito = fcp_credito;
            this.fcp_reducao_icms = fcp_reducao_icms;
            this.aliq_icms_efetivo = aliq_icms_efetivo;
            this.perc_reducao_icms_efetivo = perc_reducao_icms_efetivo;
            this.icms_fcp_st_antecipado_aliquota = icms_fcp_st_antecipado_aliquota;
            this.difal_base_dupla = difal_base_dupla;
            this.aliq_desoneracao_icms = aliq_desoneracao_icms;
            this.aliq_desoneracao_fcp = aliq_desoneracao_fcp;
            this.cod_beneficio_fiscal = cod_beneficio_fiscal;
            this.id_motivo_desoneracao_icms = id_motivo_desoneracao_icms;
            this.deduzir_icms_custo = deduzir_icms_custo;
            this.deduzir_icms_desonerado = deduzir_icms_desonerado;
            this.somar_ipi_base_difal_fcp = somar_ipi_base_difal_fcp;
            this.tipo_base_dupla = tipo_base_dupla;
            this.utiliza_lucro_base_icms = utiliza_lucro_base_icms;
            this.utiliza_lucro_base_pis = utiliza_lucro_base_pis;
            this.utiliza_lucro_base_cofins = utiliza_lucro_base_cofins;
            this.codigo_ws = codigo_ws;
            this.timestamp = timestamp;
            this.aliquota_diferimento_icms = aliquota_diferimento_icms;
            this.aliquota_diferimento_fcp = aliquota_diferimento_fcp;
        }
    }
}
