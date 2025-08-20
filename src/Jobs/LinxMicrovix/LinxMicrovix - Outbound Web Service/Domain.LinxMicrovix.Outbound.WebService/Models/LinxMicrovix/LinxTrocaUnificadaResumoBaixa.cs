
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixa
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal_baixa { get; private set; }
        public Int32? empresa_baixa { get; private set; }
        public string? cnpj_empresa_baixa { get; private set; }
        public Int32? id_troca_baixa { get; private set; }
        public Int64? id_troca_unificada_resumo_vendas_itens { get; private set; }
        public DateTime? data_troca_baixa { get; private set; }
        public Int32? transacao_baixa { get; private set; }
        public string? descricao_empresa_baixa { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxTrocaUnificadaResumoBaixa() { }

        public LinxTrocaUnificadaResumoBaixa(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxTrocaUnificadaResumoBaixa record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal_baixa = CustomConvertersExtensions.ConvertToInt32Validation(record.portal_baixa);
            this.empresa_baixa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa_baixa);
            this.id_troca_baixa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_troca_baixa);
            this.transacao_baixa = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao_baixa);
            this.data_troca_baixa = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_troca_baixa);
            this.id_troca_unificada_resumo_vendas_itens = CustomConvertersExtensions.ConvertToInt64Validation(record.id_troca_unificada_resumo_vendas_itens);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cnpj_empresa_baixa = record.cnpj_empresa_baixa;
            this.descricao_empresa_baixa = record.descricao_empresa_baixa;
        }
    }
}
