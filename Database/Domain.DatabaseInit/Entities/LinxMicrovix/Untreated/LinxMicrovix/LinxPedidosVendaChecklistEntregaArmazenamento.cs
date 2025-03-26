using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxPedidosVendaChecklistEntregaArmazenamento", Schema = "untreated")]
    public class LinxPedidosVendaChecklistEntregaArmazenamento
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_checklist_entrega_armazenamento { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }
    }
}
