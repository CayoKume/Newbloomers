using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaMarcas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaMarcas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? codigo_marca { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_marca { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? linhas { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
