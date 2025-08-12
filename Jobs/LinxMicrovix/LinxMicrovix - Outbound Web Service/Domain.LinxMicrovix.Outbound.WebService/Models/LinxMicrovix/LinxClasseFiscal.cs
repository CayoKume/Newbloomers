
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClasseFiscal
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32 portal { get; private set; }
        public Int32 id_classe_fiscal { get; private set; }
        public string? descricao { get; private set; }
        public bool excluido { get; private set; }
        public Int64 timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClasseFiscal() { }

        public LinxClasseFiscal(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClasseFiscal record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_classe_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_classe_fiscal);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
