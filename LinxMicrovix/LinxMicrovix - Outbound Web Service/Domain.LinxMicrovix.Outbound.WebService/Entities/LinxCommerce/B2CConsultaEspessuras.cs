using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaEspessuras
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_espessura { get; private set; }

        [LengthValidation(length: 100, propertyName: "nome_espessura")]
        public string? nome_espessura { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaEspessuras() { }

        public B2CConsultaEspessuras(
            List<ValidationResult> listValidations,
            string? codigo_espessura,
            string? nome_espessura,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_espessura =
                ConvertToInt32Validation.IsValid(codigo_espessura, "codigo_espessura", listValidations) ?
                Convert.ToInt32(codigo_espessura) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_espessura = nome_espessura;
            this.recordXml = recordXml;
        }
    }
}
