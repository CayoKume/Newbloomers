using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaTags", Schema = "linx_microvix_commerce")]
    public class B2CConsultaTags
    {
        public DateTime? lastupdateon { get; set; }

        public Int32? portal { get; set; }

        public Int32? id_pedido_item { get; set; }

        [LengthValidation(length: 300, propertyName: "descricao")]
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
            List<ValidationResult> listValidations,
            string? portal,
            string? id_pedido_item,
            string? descricao,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido_item =
                ConvertToInt32Validation.IsValid(id_pedido_item, "id_pedido_item", listValidations) ?
                Convert.ToInt32(id_pedido_item) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
            this.recordXml = recordXml;
        }
    }
}
