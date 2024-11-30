using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaImagensHD
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_imagem { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(200)")]
        [LengthValidation(length: 200, propertyName: "url_imagem_blob")]
        public string? url_imagem_blob { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaImagensHD() { }

        public B2CConsultaImagensHD(
            List<ValidationResult> listValidations,
            string? identificador_imagem,
            string? codigoproduto,
            string? timestamp,
            string? url_imagem_blob,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.identificador_imagem =
                String.IsNullOrEmpty(identificador_imagem) ? null
                : Guid.Parse(identificador_imagem);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt32(codigoproduto);

            this.url_imagem_blob = url_imagem_blob;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
