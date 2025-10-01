
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMarcas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_marca { get; private set; }
        public string? desc_marca { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMarcas() { }

        public LinxMarcas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMarcas record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_marca = CustomConvertersExtensions.ConvertToInt32Validation(record.id_marca);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.desc_marca = record.desc_marca;
            this.codigo_integracao_ws = record.codigo_integracao_ws;
        }
    }
}
