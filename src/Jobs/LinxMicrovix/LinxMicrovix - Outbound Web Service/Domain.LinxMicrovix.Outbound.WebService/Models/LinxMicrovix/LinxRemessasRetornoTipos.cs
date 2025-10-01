
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRemessasRetornoTipos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_remessa_retorno_tipos { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRemessasRetornoTipos() { }

        public LinxRemessasRetornoTipos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxRemessasRetornoTipos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_remessa_retorno_tipos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessa_retorno_tipos);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
