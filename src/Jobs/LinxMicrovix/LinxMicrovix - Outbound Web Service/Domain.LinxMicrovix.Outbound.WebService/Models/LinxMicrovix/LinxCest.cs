
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCest
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_cest { get; private set; }
        public string? descricao { get; private set; }
        public string? cest { get; private set; }
        public Int32? id_segmento_mercadoria_bem { get; private set; }
        public bool? ativo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCest() { }

        public LinxCest(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCest record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_cest = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cest);
            this.id_segmento_mercadoria_bem = CustomConvertersExtensions.ConvertToInt32Validation(record.id_segmento_mercadoria_bem);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
            this.cest = record.cest;
        }
    }
}
