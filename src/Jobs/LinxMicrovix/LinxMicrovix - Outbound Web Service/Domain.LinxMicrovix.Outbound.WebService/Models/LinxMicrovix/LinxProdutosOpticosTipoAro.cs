
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosOpticosTipoAro
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_tipo_aro { get; private set; }
        public string? tipo_aro { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosOpticosTipoAro() { }

        public LinxProdutosOpticosTipoAro(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosOpticosTipoAro record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_tipo_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tipo_aro);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.tipo_aro = record.tipo_aro;
        }
    }
}
