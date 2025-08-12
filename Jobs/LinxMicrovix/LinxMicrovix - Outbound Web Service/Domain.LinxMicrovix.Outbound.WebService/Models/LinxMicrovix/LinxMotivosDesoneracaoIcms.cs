
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcms
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_motivos_desoneracao_icms { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMotivosDesoneracaoIcms() { }

        public LinxMotivosDesoneracaoIcms(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMotivosDesoneracaoIcms record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_motivos_desoneracao_icms = CustomConvertersExtensions.ConvertToInt32Validation(record.id_motivos_desoneracao_icms);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
