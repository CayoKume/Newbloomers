
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxValeOrdemServicoExterna
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_vale_ordem_servico_externa { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? numero_controle { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxValeOrdemServicoExterna() { }

        public LinxValeOrdemServicoExterna(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxValeOrdemServicoExterna record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_vale_ordem_servico_externa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vale_ordem_servico_externa);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cnpj_emp = record.cnpj_emp;
            this.numero_controle = record.numero_controle;
        }
    }
}
