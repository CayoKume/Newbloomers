using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaTipoEncomenda", Schema = "linx_microvix_commerce")]
    public class B2CConsultaTipoEncomenda
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_tipo_encomenda { get; private set; }

        [LengthValidation(length: 100, propertyName: "nm_tipo_encomenda")]
        public string? nm_tipo_encomenda { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaTipoEncomenda() { }

        public B2CConsultaTipoEncomenda(
            List<ValidationResult> listValidations,
            string? id_tipo_encomenda,
            string? nm_tipo_encomenda,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tipo_encomenda =
                ConvertToInt32Validation.IsValid(id_tipo_encomenda, "id_tipo_encomenda", listValidations) ?
                Convert.ToInt32(id_tipo_encomenda) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nm_tipo_encomenda = nm_tipo_encomenda;
            this.recordXml = recordXml;
        }
    }
}
