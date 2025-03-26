using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMotivoDesconto", Schema = "linx_microvix_erp")]
    public class LinxMotivoDesconto
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_motivo_desconto { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? desc_motivo_desconto { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
