using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaImagensHD", Schema = "linx_microvix_commerce")]
    public class B2CConsultaImagensHD
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_imagem { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? url_imagem_blob { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
