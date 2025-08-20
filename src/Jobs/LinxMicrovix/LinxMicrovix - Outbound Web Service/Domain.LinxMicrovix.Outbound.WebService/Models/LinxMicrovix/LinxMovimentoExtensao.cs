
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoExtensao
    {
        public DateTime? lastupdateon { get; private set; }
        public Guid? identificador { get; private set; }
        public Int32? portal { get; private set; }
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

        public LinxMovimentoExtensao(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoExtensao record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.identificador = Guid.Parse(record.identificador);
            this.base_fcp_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_fcp_st);
            this.valor_fcp_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_fcp_st);
            this.aliq_fcp_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_fcp_st);
            this.base_icms_fcp_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_icms_fcp_st);
            this.valor_icms_fcp_st = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_icms_fcp_st);
            this.base_icms_fcp_st_retido = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_icms_fcp_st_retido);
            this.valor_icms_fcp_st_retido = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_icms_fcp_st_retido);
            this.base_icms_fcp_st_antecipado = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_icms_fcp_st_antecipado);
            this.valor_icms_fcp_st_antecipado = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_icms_fcp_st_antecipado);
            this.aliquota_icms_fcp_st_antecipado = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliquota_icms_fcp_st_antecipado);
            this.valor_iss = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_iss);
            this.icms_fcp_aliquota = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_fcp_aliquota);
            this.icms_fcp_base_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_fcp_base_item);
            this.icms_fcp_valor_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_fcp_valor_item);
            this.icms_base_partilha = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_base_partilha);
            this.aliq_difal_interna_uf_destinatario = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_difal_interna_uf_destinatario);
            this.aliq_difal_interestadual_uf_envolvidas = CustomConvertersExtensions.ConvertToDecimalValidation(record.aliq_difal_interestadual_uf_envolvidas);
            this.icms_item_perc_partilha_destino = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_item_perc_partilha_destino);
            this.icms_item_perc_partilha_origem = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_item_perc_partilha_origem);
            this.icms_st_antecipado_base_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_antecipado_base_item);
            this.icms_suportado_valor_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_suportado_valor_item);
            this.icms_suportado_valor_unitario = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_suportado_valor_unitario);
            this.icms_st_pago_base = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_pago_base);
            this.icms_st_pago_valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_pago_valor);
            this.icms_st_pago_aliq = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_st_pago_aliq);
            this.icms_para_st_pago_valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.icms_para_st_pago_valor);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.tipo_tributacao_iss = CustomConvertersExtensions.ConvertToInt32Validation(record.tipo_tributacao_iss);
            this.id_motivo_desconto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_motivo_desconto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo_pacote = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_pacote);
            this.codigo_itens_associados = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_itens_associados);
            this.codigo_kit = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_kit);
            
        }
    }
}
