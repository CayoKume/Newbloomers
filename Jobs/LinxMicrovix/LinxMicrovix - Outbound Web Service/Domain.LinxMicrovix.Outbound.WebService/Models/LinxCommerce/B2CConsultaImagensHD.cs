using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaImagensHD
    {
        public DateTime? lastupdateon { get; private set; }
        public Guid? identificador_imagem { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int64? timestamp { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaImagensHD record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.identificador_imagem = String.IsNullOrEmpty(record.identificador_imagem) ? null : Guid.Parse(record.identificador_imagem);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt32Validation(record.codigoproduto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.url_imagem_blob = record.url_imagem_blob;
            this.recordXml = recordXml;
        }
    }
}
