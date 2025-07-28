namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoExtensao
    {
        public string? identificador { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? transacao { get; set; }
        public string? base_fcp_st { get; set; }
        public string? valor_fcp_st { get; set; }
        public string? aliq_fcp_st { get; set; }
        public string? base_icms_fcp_st { get; set; }
        public string? valor_icms_fcp_st { get; set; }
        public string? base_icms_fcp_st_retido { get; set; }
        public string? valor_icms_fcp_st_retido { get; set; }
        public string? base_icms_fcp_st_antecipado { get; set; }
        public string? valor_icms_fcp_st_antecipado { get; set; }
        public string? aliquota_icms_fcp_st_antecipado { get; set; }
        public string? timestamp { get; set; }
        public string? valor_iss { get; set; }
        public string? tipo_tributacao_iss { get; set; }
        public string? icms_fcp_aliquota { get; set; }
        public string? icms_fcp_base_item { get; set; }
        public string? icms_fcp_valor_item { get; set; }
        public string? icms_base_partilha { get; set; }
        public string? aliq_difal_interna_uf_destinatario { get; set; }
        public string? aliq_difal_interestadual_uf_envolvidas { get; set; }
        public string? icms_item_perc_partilha_destino { get; set; }
        public string? icms_item_perc_partilha_origem { get; set; }
        public string? codigo_pacote { get; set; }
        public string? codigo_itens_associados { get; set; }
        public string? codigo_kit { get; set; }
        public string? id_motivo_desconto { get; set; }
        public string? icms_st_antecipado_base_item { get; set; }
        public string? icms_suportado_valor_item { get; set; }
        public string? icms_suportado_valor_unitario { get; set; }
        public string? icms_st_pago_base { get; set; }
        public string? icms_st_pago_valor { get; set; }
        public string? icms_st_pago_aliq { get; set; }
        public string? icms_para_st_pago_valor { get; set; }
    }
}
