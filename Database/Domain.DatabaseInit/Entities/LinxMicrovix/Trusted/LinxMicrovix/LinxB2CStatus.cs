using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxB2CStatus", Schema = "linx_microvix_erp")]
    public class LinxB2CStatus
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_status { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? descricao_status { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
