
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCentroCusto
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public string? CNPJ { get; private set; }
        public Int32? id_centrocusto { get; private set; }
        public string? nome_centrocusto { get; private set; }
        public bool? ativo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCentroCusto() { }

        public LinxCentroCusto(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCentroCusto record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_centrocusto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_centrocusto);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.CNPJ = record.CNPJ;
            this.nome_centrocusto = record.nome_centrocusto;
        }
    }
}
