
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxFaturasOrigem
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigo_fatura { get; private set; }
        public Int64? codigo_fatura_origem { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFaturasOrigem() { }

        public LinxFaturasOrigem(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxFaturasOrigem record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_fatura = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_fatura);
            this.codigo_fatura_origem = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_fatura_origem);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
        }
    }
}
