using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosCodBar
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; set; }

        public Int64? cod_produto { get; set; }

        [LengthValidation(length: 20, propertyName: "cod_barra")]
        public string? cod_barra { get; set; }

        public Int64? timestamp { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosCodBar() { }

        public LinxProdutosCodBar(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_produto,
            string? cod_barra,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_barra = cod_barra;
            this.recordKey = $"[{cod_produto}]|[{cod_barra}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
