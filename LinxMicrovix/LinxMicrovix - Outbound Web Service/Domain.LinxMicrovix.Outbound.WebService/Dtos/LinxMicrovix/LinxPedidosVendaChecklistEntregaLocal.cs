using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaLocal
    {
        public string? id_checklist_entrega_local { get; private set; }
        public string? descricao { get; private set; }
        public string? timestamp { get; private set; }

        public LinxPedidosVendaChecklistEntregaLocal() { }

        public LinxPedidosVendaChecklistEntregaLocal(
            string? id_checklist_entrega_local,
            string? descricao,
            string? timestamp
        )
        {
            this.id_checklist_entrega_local = id_checklist_entrega_local;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}