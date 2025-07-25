using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaImagensHD
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Guid? identificador_imagem { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 200, propertyName: "url_imagem_blob")]
        public string? url_imagem_blob { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaImagensHD() { }

        public B2CConsultaImagensHD(
            List<ValidationResult> listValidations,
            string? identificador_imagem,
            string? codigoproduto,
            string? timestamp,
            string? url_imagem_blob,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.identificador_imagem =
                String.IsNullOrEmpty(identificador_imagem) ? null
                : Guid.Parse(identificador_imagem);

            this.codigoproduto =
                ConvertToInt32Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt32(codigoproduto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.url_imagem_blob = url_imagem_blob;
            this.recordXml = recordXml;
        }
    }
}
