using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxPedidosVendaChecklistEntregaDificuldade", Schema = "linx_microvix_erp")]
    public class LinxPedidosVendaChecklistEntregaDificuldade
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_checklist_entrega_dificuldades { get; private set; }

        [LengthValidation(length: 100, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPedidosVendaChecklistEntregaDificuldade() { }

        public LinxPedidosVendaChecklistEntregaDificuldade(
            List<ValidationResult> listValidations,
            string? id_checklist_entrega_dificuldades,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_checklist_entrega_dificuldades =
                ConvertToInt32Validation.IsValid(id_checklist_entrega_dificuldades, "id_checklist_entrega_dificuldades", listValidations) ?
                Convert.ToInt32(id_checklist_entrega_dificuldades) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
