
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaArmazenamento
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_checklist_entrega_armazenamento { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPedidosVendaChecklistEntregaArmazenamento() { }

        public LinxPedidosVendaChecklistEntregaArmazenamento(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPedidosVendaChecklistEntregaArmazenamento record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_checklist_entrega_armazenamento = CustomConvertersExtensions.ConvertToInt32Validation(record.id_checklist_entrega_armazenamento);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
