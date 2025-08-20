
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaLocal
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_checklist_entrega_local { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPedidosVendaChecklistEntregaLocal() { }

        public LinxPedidosVendaChecklistEntregaLocal(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPedidosVendaChecklistEntregaLocal record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_checklist_entrega_local = CustomConvertersExtensions.ConvertToInt32Validation(record.id_checklist_entrega_local);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
