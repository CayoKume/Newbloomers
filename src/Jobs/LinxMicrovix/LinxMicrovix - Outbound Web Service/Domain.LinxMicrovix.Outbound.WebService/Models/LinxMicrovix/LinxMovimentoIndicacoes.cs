
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoIndicacoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Guid? identificador { get; private set; }
        public Int32? cod_cliente { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoIndicacoes() { }

        public LinxMovimentoIndicacoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoIndicacoes record, string recordXml) {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.identificador = Guid.Parse(record.identificador);
        }
    }
}
