using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivil
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_estado_civil { get; private set; }

        [LengthValidation(length: 20, propertyName: "estado_civil")]
        public string? estado_civil { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClientesEstadoCivil() { }

        public B2CConsultaClientesEstadoCivil(
            List<ValidationResult> listValidations,
            string? id_estado_civil,
            string? estado_civil,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_estado_civil =
                ConvertToInt32Validation.IsValid(id_estado_civil, "id_estado_civil", listValidations) ?
                Convert.ToInt32(id_estado_civil) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.estado_civil = estado_civil;
            this.recordXml = recordXml;
        }
    }
}
