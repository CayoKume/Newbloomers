
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxUnidades
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? idUnidade { get; private set; }
        public string? unidade { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxUnidades() { }

        public LinxUnidades(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxUnidades record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.unidade = record.unidade;
            this.descricao = record.descricao;
        }
    }
}
