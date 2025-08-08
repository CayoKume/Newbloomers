using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaFormasPagamento
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? cod_forma_pgto { get; private set; }
        public string? forma_pgto { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaFormasPagamento() { }

        public B2CConsultaFormasPagamento(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaFormasPagamento record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.cod_forma_pgto = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_forma_pgto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt32Validation(record.timestamp);

            this.forma_pgto = record.forma_pgto;
            this.recordXml = recordXml;
        }
    }
}
