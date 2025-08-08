using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosDimensoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public decimal? altura { get; private set; }
        public decimal? comprimento { get; private set; }
        public Int64? timestamp { get; private set; }
        public decimal? largura { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosDimensoes() { }

        public B2CConsultaProdutosDimensoes(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosDimensoes record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.altura = CustomConvertersExtensions.ConvertToDecimalValidation(record.altura);
            this.comprimento = CustomConvertersExtensions.ConvertToDecimalValidation(record.comprimento);
            this.largura = CustomConvertersExtensions.ConvertToDecimalValidation(record.largura);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.recordXml = recordXml;
        }
    }
}
