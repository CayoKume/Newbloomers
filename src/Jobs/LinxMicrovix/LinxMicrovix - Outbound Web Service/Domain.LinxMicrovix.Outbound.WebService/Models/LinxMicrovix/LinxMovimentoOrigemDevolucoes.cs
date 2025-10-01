
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoOrigemDevolucoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Guid? identificador { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? nota_origem { get; private set; }
        public Int32? ecf_origem { get; private set; }
        public DateTime? data_origem { get; private set; }
        public string? serie_origem { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoOrigemDevolucoes() { }

        public LinxMovimentoOrigemDevolucoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoOrigemDevolucoes record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.nota_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.nota_origem);
            this.ecf_origem = CustomConvertersExtensions.ConvertToInt32Validation(record.ecf_origem);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.identificador = Guid.Parse(record.identificador);
            this.data_origem = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_origem);
            this.cnpj_emp = record.cnpj_emp;
            this.serie_origem = record.serie_origem;
        }
    }
}
