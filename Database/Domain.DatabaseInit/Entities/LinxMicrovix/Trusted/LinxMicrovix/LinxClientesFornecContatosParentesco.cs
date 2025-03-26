using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxClientesFornecContatosParentesco", Schema = "linx_microvix_erp")]
    public class LinxClientesFornecContatosParentesco
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string id_parentesco { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao_parentesco { get; private set; }

        [Column(TypeName = "bigint")]
        public string timestamp { get; private set; }
    }
}
