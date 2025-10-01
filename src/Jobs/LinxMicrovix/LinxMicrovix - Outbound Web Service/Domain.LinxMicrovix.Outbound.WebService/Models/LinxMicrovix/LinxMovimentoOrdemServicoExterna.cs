
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExterna
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_movimento_ordem_servico_externa { get; private set; }
        public Guid? identificador { get; private set; }
        public string? codigo_ordem_servico { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoOrdemServicoExterna() { }

        public LinxMovimentoOrdemServicoExterna(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoOrdemServicoExterna record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_movimento_ordem_servico_externa = CustomConvertersExtensions.ConvertToInt32Validation(record.id_movimento_ordem_servico_externa);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.identificador = Guid.Parse(record.identificador);
            this.codigo_ordem_servico = record.codigo_ordem_servico;
        }
    }
}
