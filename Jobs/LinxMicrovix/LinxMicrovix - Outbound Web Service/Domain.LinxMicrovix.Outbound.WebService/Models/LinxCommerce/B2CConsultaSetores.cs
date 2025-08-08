using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaSetores
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_setor { get; private set; }
        public string? nome_setor { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaSetores() { }

        public B2CConsultaSetores(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaSetores record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_setor = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_setor);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_setor = record.nome_setor;
            this.recordXml = recordXml;
        }
    }
}
