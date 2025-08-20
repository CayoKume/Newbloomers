using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaMarcas
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_marca { get; private set; }

        [LengthValidation(length: 100, propertyName: "nome_marca")]
        public string? nome_marca { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 250, propertyName: "linhas")]
        public string? linhas { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaMarcas() { }

        public B2CConsultaMarcas(
            List<ValidationResult> listValidations,
            string? codigo_marca,
            string? nome_marca,
            string? timestamp,
            string? linhas,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_marca =
                ConvertToInt32Validation.IsValid(codigo_marca, "codigo_marca", listValidations) ?
                Convert.ToInt32(codigo_marca) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_marca = nome_marca;
            this.linhas = linhas;
            this.recordXml = recordXml;
        }
    }
}
