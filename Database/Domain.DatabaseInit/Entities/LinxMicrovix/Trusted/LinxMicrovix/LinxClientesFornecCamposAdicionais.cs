using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxClientesFornecCamposAdicionais", Schema = "linx_microvix_erp")]
    public class LinxClientesFornecCamposAdicionais
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string cod_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? campo { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? valor { get; private set; }
    }
}
