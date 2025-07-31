using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaImagens
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_imagem { get; private set; }

        [LengthValidation(length: 32, propertyName: "md5")]
        public string? md5 { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 4000, propertyName: "url_imagem_blob")]
        public string? url_imagem_blob { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaImagens() { }

        public B2CConsultaImagens(
            List<ValidationResult> listValidations,
            string? id_imagem,
            string? md5,
            string? timestamp,
            string? portal,
            string? url_imagem_blob,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_imagem =
                ConvertToInt32Validation.IsValid(id_imagem, "id_imagem", listValidations) ?
                Convert.ToInt32(id_imagem) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.md5 = md5;
            this.url_imagem_blob = url_imagem_blob;
            this.recordXml = recordXml;
        }
    }
}
