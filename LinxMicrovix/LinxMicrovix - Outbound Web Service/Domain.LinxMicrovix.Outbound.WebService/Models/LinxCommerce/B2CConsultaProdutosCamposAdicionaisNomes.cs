using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomes
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_campo { get; private set; }

        public Int32? ordem { get; private set; }

        [LengthValidation(length: 30, propertyName: "legenda")]
        public string? legenda { get; private set; }

        [LengthValidation(length: 1, propertyName: "tipo")]
        public string? tipo { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisNomes() { }

        public B2CConsultaProdutosCamposAdicionaisNomes(
            List<ValidationResult> listValidations,
            string? id_campo,
            string? ordem,
            string? legenda,
            string? tipo,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_campo =
                ConvertToInt32Validation.IsValid(id_campo, "id_campo", listValidations) ?
                Convert.ToInt32(id_campo) :
                0;

            this.ordem =
                ConvertToInt32Validation.IsValid(ordem, "ordem", listValidations) ?
                Convert.ToInt32(ordem) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.legenda = legenda;
            this.tipo = tipo;
            this.recordXml = recordXml;
        }
    }
}
