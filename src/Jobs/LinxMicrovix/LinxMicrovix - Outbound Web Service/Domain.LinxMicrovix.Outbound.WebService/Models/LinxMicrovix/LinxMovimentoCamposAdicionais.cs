
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoCamposAdicionais
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_ordservprod { get; private set; }
        public Int32? transacao { get; private set; }
        public string? paciente { get; private set; }
        public string? codigo_gerencial { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoCamposAdicionais() { }

        public LinxMovimentoCamposAdicionais(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoCamposAdicionais record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_ordservprod = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ordservprod);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.paciente = record.paciente;
            this.codigo_gerencial = record.codigo_gerencial;
        }
    }
}
