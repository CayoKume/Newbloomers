using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaDificuldade
    {
        public string? id_checklist_entrega_dificuldades { get; private set; }
        public string? descricao { get; private set; }
        public string? timestamp { get; private set; }

        public LinxPedidosVendaChecklistEntregaDificuldade() { }

        public LinxPedidosVendaChecklistEntregaDificuldade(
            string? id_checklist_entrega_dificuldades,
            string? descricao,
            string? timestamp
        )
        {
            this.id_checklist_entrega_dificuldades = id_checklist_entrega_dificuldades;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}