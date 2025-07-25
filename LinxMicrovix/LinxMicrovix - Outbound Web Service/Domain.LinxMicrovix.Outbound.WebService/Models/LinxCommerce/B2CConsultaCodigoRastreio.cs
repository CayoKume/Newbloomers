using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaCodigoRastreio
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_pedido { get; private set; }

        public Int32? documento { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        [LengthValidation(length: 20, propertyName: "codigo_rastreio")]
        public string? codigo_rastreio { get; private set; }

        [LengthValidation(length: 20, propertyName: "sequencia_volume")]
        public string? sequencia_volume { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaCodigoRastreio() { }

        public B2CConsultaCodigoRastreio(
            List<ValidationResult> listValidations,
            string? id_pedido,
            string? documento,
            string? serie,
            string? codigo_rastreio,
            string? sequencia_volume,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido =
                ConvertToInt32Validation.IsValid(id_pedido, "id_pedido", listValidations) ?
                Convert.ToInt32(id_pedido) :
                0;

            this.documento =
                ConvertToInt32Validation.IsValid(documento, "documento", listValidations) ?
                Convert.ToInt32(documento) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.serie = serie;
            this.codigo_rastreio = codigo_rastreio;
            this.sequencia_volume = sequencia_volume;
            this.recordXml = recordXml;
        }
    }
}
