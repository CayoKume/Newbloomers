
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxLojasParametros
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public decimal? percentual_minimo_antecipacao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxLojasParametros() { }

        public LinxLojasParametros(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxLojasParametros record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.percentual_minimo_antecipacao = CustomConvertersExtensions.ConvertToDecimalValidation(record.percentual_minimo_antecipacao);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            
        }
    }
}
