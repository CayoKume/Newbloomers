using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaGrade2
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_grade2 { get; private set; }

        [LengthValidation(length: 100, propertyName: "nome_grade2")]
        public string? nome_grade2 { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaGrade2() { }

        public B2CConsultaGrade2(
            List<ValidationResult> listValidations,
            string? codigo_grade2,
            string? nome_grade2,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_grade2 =
                ConvertToInt32Validation.IsValid(codigo_grade2, "codigo_grade2", listValidations) ?
                Convert.ToInt32(codigo_grade2) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_grade2 = nome_grade2;
            this.recordXml = recordXml;
        }
    }
}
