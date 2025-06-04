using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce
{
    public class B2CConsultaProdutosDimensoes
    {
        [SkipProperty]
        public Int32 id { get; set; }

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
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? altura,
            string? comprimento,
            string? timestamp,
            string? largura,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.altura =
                ConvertToDecimalValidation.IsValid(altura, "altura", listValidations) ?
                Convert.ToDecimal(altura, new CultureInfo("en-US")) :
                0;

            this.comprimento =
                ConvertToDecimalValidation.IsValid(comprimento, "comprimento", listValidations) ?
                Convert.ToDecimal(comprimento, new CultureInfo("en-US")) :
                0;

            this.largura =
                ConvertToDecimalValidation.IsValid(largura, "largura", listValidations) ?
                Convert.ToDecimal(largura, new CultureInfo("en-US")) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.recordXml = recordXml;
        }
    }
}
