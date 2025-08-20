
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaImagens
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_imagem { get; private set; }
        public string? md5 { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }
        public string? url_imagem_blob { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaImagens() { }

        public B2CConsultaImagens(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaImagens record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);

            this.id_imagem = CustomConvertersExtensions.ConvertToInt32Validation(record.id_imagem);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.md5 = record.md5;
            this.url_imagem_blob = record.url_imagem_blob;
            this.recordXml = recordXml;
        }
    }
}
