
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxEspessuras
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_espessura { get; private set; }
        public string? desc_espessura { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public bool? ativo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxEspessuras() { }

        public LinxEspessuras(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxEspessuras record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_espessura = CustomConvertersExtensions.ConvertToInt32Validation(record.id_espessura);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.desc_espessura = record.desc_espessura;
            this.codigo_integracao_ws = record.codigo_integracao_ws;
        }
    }
}
