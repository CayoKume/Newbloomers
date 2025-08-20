
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxB2CStatus
    {
        
        public DateTime lastupdateon { get; private set; }
        public Int32? id_status { get; private set; }
        public string? descricao_status { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxB2CStatus() { }

        public LinxB2CStatus(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxB2CStatus record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_status = CustomConvertersExtensions.ConvertToInt32Validation(record.id_status);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao_status = record.descricao_status;
            this.recordKey = $"[{record.id_status}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
