
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxNfse
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_nfse { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? documento { get; private set; }
        public string? codigo_verificacao { get; private set; }
        public Int32? id_nfse_situacao { get; private set; }
        public Guid? identificador { get; private set; }
        public DateTime? dt_insert { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNfse() { }

        public LinxNfse(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNfse record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.id_nfse = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfse);
            this.id_nfse_situacao = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfse_situacao);
            this.identificador = Guid.Parse(record.identificador);
            this.dt_insert = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_insert);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo_verificacao = record.codigo_verificacao;
        }
    }
}
