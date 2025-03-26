using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxPedidosVendaChecklistEntregaDificuldade", Schema = "linx_microvix_erp")]
    public class LinxPedidosVendaChecklistEntregaDificuldade
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_checklist_entrega_dificuldades { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
