namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxConfiguracoesTributariasDetalhesSimplificado
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
    }
}
