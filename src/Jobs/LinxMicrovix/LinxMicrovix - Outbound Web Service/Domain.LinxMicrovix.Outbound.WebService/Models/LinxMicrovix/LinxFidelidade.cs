
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxFidelidade
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_fidelidade_parceiro_log { get; private set; }
        public DateTime? data_transacao { get; private set; }
        public Int32? operacao { get; private set; }
        public string? aprovado_barramento { get; private set; }
        public decimal? valor_monetario { get; private set; }
        public string? numero_cartao { get; private set; }
        public Guid? identificador_movimento { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFidelidade() { }

        public LinxFidelidade(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxFidelidade record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_fidelidade_parceiro_log = CustomConvertersExtensions.ConvertToInt32Validation(record.id_fidelidade_parceiro_log);
            this.operacao = CustomConvertersExtensions.ConvertToInt32Validation(record.operacao);
            this.data_transacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_transacao);
            this.valor_monetario = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_monetario);
            this.identificador_movimento = Guid.Parse(record.identificador_movimento);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cnpj_emp = record.cnpj_emp;
            this.aprovado_barramento = record.aprovado_barramento;
            this.numero_cartao = record.numero_cartao;
        }
    }
}
