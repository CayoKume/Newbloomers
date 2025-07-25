using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPedidosVendaChecklistEntregaLocal
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_checklist_entrega_local { get; private set; }

        [LengthValidation(length: 100, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPedidosVendaChecklistEntregaLocal() { }

        public LinxPedidosVendaChecklistEntregaLocal(
            List<ValidationResult> listValidations,
            string? id_checklist_entrega_local,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_checklist_entrega_local =
                ConvertToInt32Validation.IsValid(id_checklist_entrega_local, "id_checklist_entrega_local", listValidations) ?
                Convert.ToInt32(id_checklist_entrega_local) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
