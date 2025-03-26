
using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxLinhas", Schema = "linx_microvix_erp")]
    public class LinxLinhas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_linha { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_linha { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? coeficiente_comissao { get; private set; }
    }
}
