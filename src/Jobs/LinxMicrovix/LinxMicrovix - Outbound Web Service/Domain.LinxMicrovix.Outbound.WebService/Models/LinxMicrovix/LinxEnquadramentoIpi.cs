
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxEnquadramentoIpi
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_enquadramento_ipi { get; private set; }
        public string? codigo { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxEnquadramentoIpi() { }

        public LinxEnquadramentoIpi(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxEnquadramentoIpi record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_enquadramento_ipi = CustomConvertersExtensions.ConvertToInt32Validation(record.id_enquadramento_ipi);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo = record.codigo;
            this.descricao = record.descricao;
        }
    }
}
