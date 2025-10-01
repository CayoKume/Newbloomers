
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRemessasOperacoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_remessa_operacoes { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRemessasOperacoes() { }

        public LinxRemessasOperacoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxRemessasOperacoes record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_remessa_operacoes = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessa_operacoes);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
