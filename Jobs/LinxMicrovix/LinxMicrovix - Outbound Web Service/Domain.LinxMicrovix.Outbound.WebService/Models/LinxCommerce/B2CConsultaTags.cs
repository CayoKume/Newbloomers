
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaTags
    {
        public DateTime? lastupdateon { get; set; }
        public Int32? portal { get; set; }
        public Int32? id_pedido_item { get; set; }
        public string? descricao { get; set; }
        public Int64? timestamp { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaTags() { }

        public B2CConsultaTags(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaTags record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_pedido_item = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido_item);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.descricao = record.descricao;
            this.recordXml = recordXml;
        }
    }
}
