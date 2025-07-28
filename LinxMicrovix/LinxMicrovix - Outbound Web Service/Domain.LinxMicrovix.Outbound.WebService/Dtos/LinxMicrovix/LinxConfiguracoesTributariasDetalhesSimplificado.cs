namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesSimplificado
    {
        public string? portal { get; set; }
        public string? id_config_tributaria_detalhe { get; set; }
        public string? id_config_tributaria { get; set; }
        public string? cod_natureza_operacao { get; set; }
        public string? id_classe_fiscal { get; set; }
        public string? id_cst_icms_fiscal { get; set; }
        public string? id_csosn_fiscal { get; set; }
        public string? id_cfop_fiscal { get; set; }
        public string? ipi_credito { get; set; }
        public string? icms_credito { get; set; }
        public string? aliq_icms { get; set; }
        public string? perc_reducao_icms { get; set; }
        public string? aliquota_st { get; set; }
        public string? margem_st { get; set; }
        public string? timestamp { get; set; }

        public LinxConfiguracoesTributariasDetalhesSimplificado()
        {
        }

        public LinxConfiguracoesTributariasDetalhesSimplificado(string? portal, string? id_config_tributaria_detalhe, string? id_config_tributaria, string? cod_natureza_operacao, string? id_classe_fiscal, string? id_cst_icms_fiscal, string? id_csosn_fiscal, string? id_cfop_fiscal, string? ipi_credito, string? icms_credito, string? aliq_icms, string? perc_reducao_icms, string? aliquota_st, string? margem_st, string? timestamp)
        {
            this.portal = portal;
            this.id_config_tributaria_detalhe = id_config_tributaria_detalhe;
            this.id_config_tributaria = id_config_tributaria;
            this.cod_natureza_operacao = cod_natureza_operacao;
            this.id_classe_fiscal = id_classe_fiscal;
            this.id_cst_icms_fiscal = id_cst_icms_fiscal;
            this.id_csosn_fiscal = id_csosn_fiscal;
            this.id_cfop_fiscal = id_cfop_fiscal;
            this.ipi_credito = ipi_credito;
            this.icms_credito = icms_credito;
            this.aliq_icms = aliq_icms;
            this.perc_reducao_icms = perc_reducao_icms;
            this.aliquota_st = aliquota_st;
            this.margem_st = margem_st;
            this.timestamp = timestamp;
        }
    }
}
