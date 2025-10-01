
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCsosnFiscal
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_csosn_fiscal { get; private set; }
        public string? csosn_fiscal { get; private set; }
        public string? descricao { get; private set; }
        public Int32? id_csosn_fiscal_substitutiva { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCsosnFiscal() { }

        public LinxCsosnFiscal(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCsosnFiscal record, string recordXml) {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_csosn_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_csosn_fiscal);
            this.id_csosn_fiscal_substitutiva = CustomConvertersExtensions.ConvertToInt32Validation(record.id_csosn_fiscal_substitutiva);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.csosn_fiscal = record.csosn_fiscal;
            this.descricao = record.descricao;
        }
    }
}
