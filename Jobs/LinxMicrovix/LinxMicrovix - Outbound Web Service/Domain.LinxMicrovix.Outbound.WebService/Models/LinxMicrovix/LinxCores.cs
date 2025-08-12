
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCores
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_cor { get; private set; }
        public string? desc_cor { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public bool? ativo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCores() { }

        public LinxCores(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCores record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_cor = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cor);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.desc_cor = record.desc_cor;
            this.codigo_integracao_ws = record.codigo_integracao_ws;
        }
    }
}
