
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRotinaOrigem
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_rotina { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao_rotina { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRotinaOrigem() { }

        public LinxRotinaOrigem(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxRotinaOrigem record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.codigo_rotina = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_rotina);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao_rotina = record.descricao_rotina;
            this.recordKey = $"[{record.codigo_rotina}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
