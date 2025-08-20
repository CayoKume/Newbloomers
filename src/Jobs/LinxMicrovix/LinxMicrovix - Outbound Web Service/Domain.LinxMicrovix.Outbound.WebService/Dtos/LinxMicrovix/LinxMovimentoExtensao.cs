

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoExtensao
    {
        public string? identificador { get; private set; }
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? transacao { get; private set; }
        public string? base_fcp_st { get; private set; }
        public string? valor_fcp_st { get; private set; }
        public string? aliq_fcp_st { get; private set; }
        public string? base_icms_fcp_st { get; private set; }
        public string? valor_icms_fcp_st { get; private set; }
        public string? base_icms_fcp_st_retido { get; private set; }
        public string? valor_icms_fcp_st_retido { get; private set; }
        public string? base_icms_fcp_st_antecipado { get; private set; }
        public string? valor_icms_fcp_st_antecipado { get; private set; }
        public string? aliquota_icms_fcp_st_antecipado { get; private set; }
        public string? timestamp { get; private set; }
        public string? valor_iss { get; private set; }
        public string? tipo_tributacao_iss { get; private set; }
        public string? icms_fcp_aliquota { get; private set; }
        public string? icms_fcp_base_item { get; private set; }
        public string? icms_fcp_valor_item { get; private set; }
        public string? icms_base_partilha { get; private set; }
        public string? aliq_difal_interna_uf_destinatario { get; private set; }
        public string? aliq_difal_interestadual_uf_envolvidas { get; private set; }
        public string? icms_item_perc_partilha_destino { get; private set; }
        public string? icms_item_perc_partilha_origem { get; private set; }
        public string? codigo_pacote { get; private set; }
        public string? codigo_itens_associados { get; private set; }
        public string? codigo_kit { get; private set; }
        public string? id_motivo_desconto { get; private set; }
        public string? icms_st_antecipado_base_item { get; private set; }
        public string? icms_suportado_valor_item { get; private set; }
        public string? icms_suportado_valor_unitario { get; private set; }
        public string? icms_st_pago_base { get; private set; }
        public string? icms_st_pago_valor { get; private set; }
        public string? icms_st_pago_aliq { get; private set; }
        public string? icms_para_st_pago_valor { get; private set; }

        public LinxMovimentoExtensao() { }

        public LinxMovimentoExtensao(
            string? identificador,
            string? portal,
            string? cnpj_emp,
            string? transacao,
            string? base_fcp_st,
            string? valor_fcp_st,
            string? aliq_fcp_st,
            string? base_icms_fcp_st,
            string? valor_icms_fcp_st,
            string? base_icms_fcp_st_retido,
            string? valor_icms_fcp_st_retido,
            string? base_icms_fcp_st_antecipado,
            string? valor_icms_fcp_st_antecipado,
            string? aliquota_icms_fcp_st_antecipado,
            string? timestamp,
            string? valor_iss,
            string? tipo_tributacao_iss,
            string? icms_fcp_aliquota,
            string? icms_fcp_base_item,
            string? icms_fcp_valor_item,
            string? icms_base_partilha,
            string? aliq_difal_interna_uf_destinatario,
            string? aliq_difal_interestadual_uf_envolvidas,
            string? icms_item_perc_partilha_destino,
            string? icms_item_perc_partilha_origem,
            string? codigo_pacote,
            string? codigo_itens_associados,
            string? codigo_kit,
            string? id_motivo_desconto,
            string? icms_st_antecipado_base_item,
            string? icms_suportado_valor_item,
            string? icms_suportado_valor_unitario,
            string? icms_st_pago_base,
            string? icms_st_pago_valor,
            string? icms_st_pago_aliq,
            string? icms_para_st_pago_valor
        )
        {
            this.identificador = identificador;
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.transacao = transacao;
            this.base_fcp_st = base_fcp_st;
            this.valor_fcp_st = valor_fcp_st;
            this.aliq_fcp_st = aliq_fcp_st;
            this.base_icms_fcp_st = base_icms_fcp_st;
            this.valor_icms_fcp_st = valor_icms_fcp_st;
            this.base_icms_fcp_st_retido = base_icms_fcp_st_retido;
            this.valor_icms_fcp_st_retido = valor_icms_fcp_st_retido;
            this.base_icms_fcp_st_antecipado = base_icms_fcp_st_antecipado;
            this.valor_icms_fcp_st_antecipado = valor_icms_fcp_st_antecipado;
            this.aliquota_icms_fcp_st_antecipado = aliquota_icms_fcp_st_antecipado;
            this.timestamp = timestamp;
            this.valor_iss = valor_iss;
            this.tipo_tributacao_iss = tipo_tributacao_iss;
            this.icms_fcp_aliquota = icms_fcp_aliquota;
            this.icms_fcp_base_item = icms_fcp_base_item;
            this.icms_fcp_valor_item = icms_fcp_valor_item;
            this.icms_base_partilha = icms_base_partilha;
            this.aliq_difal_interna_uf_destinatario = aliq_difal_interna_uf_destinatario;
            this.aliq_difal_interestadual_uf_envolvidas = aliq_difal_interestadual_uf_envolvidas;
            this.icms_item_perc_partilha_destino = icms_item_perc_partilha_destino;
            this.icms_item_perc_partilha_origem = icms_item_perc_partilha_origem;
            this.codigo_pacote = codigo_pacote;
            this.codigo_itens_associados = codigo_itens_associados;
            this.codigo_kit = codigo_kit;
            this.id_motivo_desconto = id_motivo_desconto;
            this.icms_st_antecipado_base_item = icms_st_antecipado_base_item;
            this.icms_suportado_valor_item = icms_suportado_valor_item;
            this.icms_suportado_valor_unitario = icms_suportado_valor_unitario;
            this.icms_st_pago_base = icms_st_pago_base;
            this.icms_st_pago_valor = icms_st_pago_valor;
            this.icms_st_pago_aliq = icms_st_pago_aliq;
            this.icms_para_st_pago_valor = icms_para_st_pago_valor;
        }
    }
}