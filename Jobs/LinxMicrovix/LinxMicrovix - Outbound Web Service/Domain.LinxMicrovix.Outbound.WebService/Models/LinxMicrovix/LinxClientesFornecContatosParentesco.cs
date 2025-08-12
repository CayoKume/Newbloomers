
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClientesFornecContatosParentesco
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32 id_parentesco { get; private set; }
        public string? descricao_parentesco { get; private set; }
        public Int64 timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesFornecContatosParentesco() { }

        public LinxClientesFornecContatosParentesco(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornecContatosParentesco record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_parentesco = CustomConvertersExtensions.ConvertToInt32Validation(record.id_parentesco);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao_parentesco = record.descricao_parentesco;
        }
    }
}
