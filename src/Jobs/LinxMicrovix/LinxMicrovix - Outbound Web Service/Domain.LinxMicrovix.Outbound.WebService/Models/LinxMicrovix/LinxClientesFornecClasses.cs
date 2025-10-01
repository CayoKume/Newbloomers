
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClientesFornecClasses
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32 portal { get; private set; }
        public Int32 cod_cliente { get; private set; }
        public Int32 cod_classe { get; private set; }
        public string? nome_classe { get; private set; }
        public Int64 timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesFornecClasses() { }

        public LinxClientesFornecClasses(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClientesFornecClasses record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.cod_classe = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_classe);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.nome_classe = record.nome_classe;
        }
    }
}
