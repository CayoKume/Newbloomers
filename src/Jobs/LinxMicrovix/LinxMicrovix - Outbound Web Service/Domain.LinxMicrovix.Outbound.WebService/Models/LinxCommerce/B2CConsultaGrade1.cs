
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaGrade1
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_grade1 { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaGrade1 record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_grade1 = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_grade1);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal); 
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_grade1 = record.nome_grade1;
            this.recordXml = recordXml;
        }
    }
}
