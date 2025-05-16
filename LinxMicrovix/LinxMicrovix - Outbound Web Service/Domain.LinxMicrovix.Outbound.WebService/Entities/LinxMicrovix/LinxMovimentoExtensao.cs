using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoExtensao
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Guid? identificador { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? transacao { get; private set; }

        public decimal? base_fcp_st { get; private set; }

        public decimal? valor_fcp_st { get; private set; }

        public decimal? aliq_fcp_st { get; private set; }

        public decimal? base_icms_fcp_st { get; private set; }

        public decimal? valor_icms_fcp_st { get; private set; }

        public decimal? base_icms_fcp_st_retido { get; private set; }

        public decimal? valor_icms_fcp_st_retido { get; private set; }

        public decimal? base_icms_fcp_st_antecipado { get; private set; }

        public decimal? valor_icms_fcp_st_antecipado { get; private set; }

        public decimal? aliquota_icms_fcp_st_antecipado { get; private set; }

        public Int64? timestamp { get; private set; }

        public decimal? valor_iss { get; private set; }

        public Int32? tipo_tributacao_iss { get; private set; }

        public decimal? icms_fcp_aliquota { get; private set; }

        public decimal? icms_fcp_base_item { get; private set; }

        public decimal? icms_fcp_valor_item { get; private set; }

        public decimal? icms_base_partilha { get; private set; }

        public decimal? aliq_difal_interna_uf_destinatario { get; private set; }

        public decimal? aliq_difal_interestadual_uf_envolvidas { get; private set; }

        public decimal? icms_item_perc_partilha_destino { get; private set; }

        public decimal? icms_item_perc_partilha_origem { get; private set; }

        public Int64? codigo_pacote { get; private set; }

        public Int64? codigo_itens_associados { get; private set; }

        public Int64? codigo_kit { get; private set; }

        public Int32? id_motivo_desconto { get; private set; }

        public decimal? icms_st_antecipado_base_item { get; private set; }

        public decimal? icms_suportado_valor_item { get; private set; }

        public decimal? icms_suportado_valor_unitario { get; private set; }

        public decimal? icms_st_pago_base { get; private set; }

        public decimal? icms_st_pago_valor { get; private set; }

        public decimal? icms_st_pago_aliq { get; private set; }

        public decimal? icms_para_st_pago_valor { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoExtensao() { }

        public LinxMovimentoExtensao(
            List<ValidationResult> listValidations,
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
            lastupdateon = DateTime.Now;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.base_fcp_st =
                ConvertToDecimalValidation.IsValid(base_fcp_st, "base_fcp_st", listValidations) ?
                Convert.ToDecimal(base_fcp_st, new CultureInfo("en-US")) :
                0;

            this.valor_fcp_st =
                ConvertToDecimalValidation.IsValid(valor_fcp_st, "valor_fcp_st", listValidations) ?
                Convert.ToDecimal(valor_fcp_st, new CultureInfo("en-US")) :
                0;

            this.aliq_fcp_st =
                ConvertToDecimalValidation.IsValid(aliq_fcp_st, "aliq_fcp_st", listValidations) ?
                Convert.ToDecimal(aliq_fcp_st, new CultureInfo("en-US")) :
                0;

            this.base_icms_fcp_st =
                ConvertToDecimalValidation.IsValid(base_icms_fcp_st, "base_icms_fcp_st", listValidations) ?
                Convert.ToDecimal(base_icms_fcp_st, new CultureInfo("en-US")) :
                0;

            this.valor_icms_fcp_st =
                ConvertToDecimalValidation.IsValid(valor_icms_fcp_st, "valor_icms_fcp_st", listValidations) ?
                Convert.ToDecimal(valor_icms_fcp_st, new CultureInfo("en-US")) :
                0;

            this.base_icms_fcp_st_retido =
                ConvertToDecimalValidation.IsValid(base_icms_fcp_st_retido, "base_icms_fcp_st_retido", listValidations) ?
                Convert.ToDecimal(base_icms_fcp_st_retido, new CultureInfo("en-US")) :
                0;

            this.valor_icms_fcp_st_retido =
                ConvertToDecimalValidation.IsValid(valor_icms_fcp_st_retido, "valor_icms_fcp_st_retido", listValidations) ?
                Convert.ToDecimal(valor_icms_fcp_st_retido, new CultureInfo("en-US")) :
                0;

            this.base_icms_fcp_st_antecipado =
                ConvertToDecimalValidation.IsValid(base_icms_fcp_st_antecipado, "base_icms_fcp_st_antecipado", listValidations) ?
                Convert.ToDecimal(base_icms_fcp_st_antecipado, new CultureInfo("en-US")) :
                0;

            this.valor_icms_fcp_st_antecipado =
                ConvertToDecimalValidation.IsValid(valor_icms_fcp_st_antecipado, "valor_icms_fcp_st_antecipado", listValidations) ?
                Convert.ToDecimal(valor_icms_fcp_st_antecipado, new CultureInfo("en-US")) :
                0;

            this.aliquota_icms_fcp_st_antecipado =
                ConvertToDecimalValidation.IsValid(aliquota_icms_fcp_st_antecipado, "aliquota_icms_fcp_st_antecipado", listValidations) ?
                Convert.ToDecimal(aliquota_icms_fcp_st_antecipado, new CultureInfo("en-US")) :
                0;

            this.valor_iss =
                ConvertToDecimalValidation.IsValid(valor_iss, "valor_iss", listValidations) ?
                Convert.ToDecimal(valor_iss, new CultureInfo("en-US")) :
                0;

            this.icms_fcp_aliquota =
                ConvertToDecimalValidation.IsValid(icms_fcp_aliquota, "icms_fcp_aliquota", listValidations) ?
                Convert.ToDecimal(icms_fcp_aliquota, new CultureInfo("en-US")) :
                0;

            this.icms_fcp_base_item =
                ConvertToDecimalValidation.IsValid(icms_fcp_base_item, "icms_fcp_base_item", listValidations) ?
                Convert.ToDecimal(icms_fcp_base_item, new CultureInfo("en-US")) :
                0;

            this.icms_fcp_valor_item =
                ConvertToDecimalValidation.IsValid(icms_fcp_valor_item, "icms_fcp_valor_item", listValidations) ?
                Convert.ToDecimal(icms_fcp_valor_item, new CultureInfo("en-US")) :
                0;

            this.icms_base_partilha =
                ConvertToDecimalValidation.IsValid(icms_base_partilha, "icms_base_partilha", listValidations) ?
                Convert.ToDecimal(icms_base_partilha, new CultureInfo("en-US")) :
                0;

            this.aliq_difal_interna_uf_destinatario =
                ConvertToDecimalValidation.IsValid(aliq_difal_interna_uf_destinatario, "aliq_difal_interna_uf_destinatario", listValidations) ?
                Convert.ToDecimal(aliq_difal_interna_uf_destinatario, new CultureInfo("en-US")) :
                0;

            this.aliq_difal_interestadual_uf_envolvidas =
                ConvertToDecimalValidation.IsValid(aliq_difal_interestadual_uf_envolvidas, "aliq_difal_interestadual_uf_envolvidas", listValidations) ?
                Convert.ToDecimal(aliq_difal_interestadual_uf_envolvidas, new CultureInfo("en-US")) :
                0;

            this.icms_item_perc_partilha_destino =
                ConvertToDecimalValidation.IsValid(icms_item_perc_partilha_destino, "icms_item_perc_partilha_destino", listValidations) ?
                Convert.ToDecimal(icms_item_perc_partilha_destino, new CultureInfo("en-US")) :
                0;

            this.icms_item_perc_partilha_origem =
                ConvertToDecimalValidation.IsValid(icms_item_perc_partilha_origem, "icms_item_perc_partilha_origem", listValidations) ?
                Convert.ToDecimal(icms_item_perc_partilha_origem, new CultureInfo("en-US")) :
                0;

            this.icms_st_antecipado_base_item =
                ConvertToDecimalValidation.IsValid(icms_st_antecipado_base_item, "icms_st_antecipado_base_item", listValidations) ?
                Convert.ToDecimal(icms_st_antecipado_base_item, new CultureInfo("en-US")) :
                0;

            this.icms_suportado_valor_item =
                ConvertToDecimalValidation.IsValid(icms_suportado_valor_item, "icms_suportado_valor_item", listValidations) ?
                Convert.ToDecimal(icms_suportado_valor_item, new CultureInfo("en-US")) :
                0;

            this.icms_suportado_valor_unitario =
                ConvertToDecimalValidation.IsValid(icms_suportado_valor_unitario, "icms_suportado_valor_unitario", listValidations) ?
                Convert.ToDecimal(icms_suportado_valor_unitario, new CultureInfo("en-US")) :
                0;

            this.icms_st_pago_base =
                ConvertToDecimalValidation.IsValid(icms_st_pago_base, "icms_st_pago_base", listValidations) ?
                Convert.ToDecimal(icms_st_pago_base, new CultureInfo("en-US")) :
                0;

            this.icms_st_pago_valor =
                ConvertToDecimalValidation.IsValid(icms_st_pago_valor, "icms_st_pago_valor", listValidations) ?
                Convert.ToDecimal(icms_st_pago_valor, new CultureInfo("en-US")) :
                0;

            this.icms_st_pago_aliq =
                ConvertToDecimalValidation.IsValid(icms_st_pago_aliq, "icms_st_pago_aliq", listValidations) ?
                Convert.ToDecimal(icms_st_pago_aliq, new CultureInfo("en-US")) :
                0;

            this.icms_para_st_pago_valor =
                ConvertToDecimalValidation.IsValid(icms_para_st_pago_valor, "icms_para_st_pago_valor", listValidations) ?
                Convert.ToDecimal(icms_para_st_pago_valor, new CultureInfo("en-US")) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.tipo_tributacao_iss =
                ConvertToInt32Validation.IsValid(tipo_tributacao_iss, "tipo_tributacao_iss", listValidations) ?
                Convert.ToInt32(tipo_tributacao_iss) :
                0;

            this.id_motivo_desconto =
                ConvertToInt32Validation.IsValid(id_motivo_desconto, "id_motivo_desconto", listValidations) ?
                Convert.ToInt32(id_motivo_desconto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo_pacote =
                ConvertToInt64Validation.IsValid(codigo_pacote, "codigo_pacote", listValidations) ?
                Convert.ToInt64(codigo_pacote) :
                0;

            this.codigo_itens_associados =
                ConvertToInt64Validation.IsValid(codigo_itens_associados, "codigo_itens_associados", listValidations) ?
                Convert.ToInt64(codigo_itens_associados) :
                0;

            this.codigo_kit =
                ConvertToInt64Validation.IsValid(codigo_kit, "codigo_kit", listValidations) ?
                Convert.ToInt64(codigo_kit) :
                0;
        }
    }
}
