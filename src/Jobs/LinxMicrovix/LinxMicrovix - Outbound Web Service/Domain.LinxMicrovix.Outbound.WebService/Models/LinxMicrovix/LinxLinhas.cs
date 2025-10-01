
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxLinhas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_linha { get; private set; }
        public string? desc_linha { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public Int32? portal { get; private set; }
        public decimal? coeficiente_comissao { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxLinhas() { }

        public LinxLinhas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxLinhas record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_linha = CustomConvertersExtensions.ConvertToInt32Validation(record.id_linha);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.coeficiente_comissao = CustomConvertersExtensions.ConvertToDecimalValidation(record.coeficiente_comissao);
            this.desc_linha = record.desc_linha;
            this.codigo_integracao_ws = record.codigo_integracao_ws;
        }
    }
}
