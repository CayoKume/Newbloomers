
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxColecoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_colecao { get; private set; }
        public string? desc_colecao { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxColecoes() { }

        public LinxColecoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxColecoes record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_colecao = CustomConvertersExtensions.ConvertToInt32Validation(record.id_colecao);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.desc_colecao = record.desc_colecao;
            this.codigo_integracao_ws = record.codigo_integracao_ws;
        }
    }
}
