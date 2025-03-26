using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutosCamposAdicionais", Schema = "linx_microvix_erp")]
    public class LinxProdutosCamposAdicionais
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? cod_produto { get; private set; }

        [LengthValidation(length: 30, propertyName: "campo")]
        public string? campo { get; private set; }

        [LengthValidation(length: 30, propertyName: "valor")]
        public string? valor { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosCamposAdicionais() { }

        public LinxProdutosCamposAdicionais(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_produto,
            string? campo,
            string? valor,
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

            this.valor = valor;
            this.campo = campo;
            this.recordKey = $"[{cod_produto}]|[{campo}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
