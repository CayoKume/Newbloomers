using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaGrade1
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_grade1 { get; private set; }

        [LengthValidation(length: 100, propertyName: "nome_grade1")]
        public string? nome_grade1 { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaGrade1() { }

        public B2CConsultaGrade1(
            List<ValidationResult> listValidations,
            string? codigo_grade1,
            string? nome_grade1,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_grade1 =
                ConvertToInt32Validation.IsValid(codigo_grade1, "codigo_grade1", listValidations) ?
                Convert.ToInt32(codigo_grade1) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_grade1 = nome_grade1;
            this.recordXml = recordXml;
        }
    }
}
