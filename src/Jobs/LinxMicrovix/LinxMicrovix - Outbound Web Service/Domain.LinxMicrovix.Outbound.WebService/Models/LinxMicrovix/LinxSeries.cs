
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxSeries
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? serie { get; private set; }
        public Int32? id_modelo_nf { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSeries() { }

        public LinxSeries(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSeries record, string recordXml) {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_modelo_nf = CustomConvertersExtensions.ConvertToInt32Validation(record.id_modelo_nf);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.serie = record.serie;
        }
    }
}
