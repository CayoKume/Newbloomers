using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosStatus
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public string? referencia { get; private set; }
        public Int32? ativo { get; private set; }
        public Int32? b2c { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosStatus() { }

        public B2CConsultaProdutosStatus(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosStatus record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);

            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.ativo = CustomConvertersExtensions.ConvertToInt32Validation(record.ativo);
            this.b2c = CustomConvertersExtensions.ConvertToInt32Validation(record.b2c);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.referencia = record.referencia;
            this.recordXml = recordXml;
        }
    }
}
