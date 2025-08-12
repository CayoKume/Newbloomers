

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaArmazenamento
    {
        public string? id_checklist_entrega_armazenamento { get; private set; }
        public string? descricao { get; private set; }
        public string? timestamp { get; private set; }

        public LinxPedidosVendaChecklistEntregaArmazenamento() { }

        public LinxPedidosVendaChecklistEntregaArmazenamento(
            string? id_checklist_entrega_armazenamento,
            string? descricao,
            string? timestamp
        )
        {
            this.id_checklist_entrega_armazenamento = id_checklist_entrega_armazenamento;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}