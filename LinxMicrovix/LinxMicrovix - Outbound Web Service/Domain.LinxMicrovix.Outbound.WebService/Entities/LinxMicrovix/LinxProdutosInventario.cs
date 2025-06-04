using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxProdutosInventario
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int64? cod_produto { get; private set; }

        [LengthValidation(length: 20, propertyName: "cod_barra")]
        public string? cod_barra { get; private set; }

        public decimal? quantidade { get; private set; }

        public Int32? cod_deposito { get; private set; }

        public Int32? empresa { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosInventario() { }

        public LinxProdutosInventario(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_produto,
            string? cod_barra,
            string? quantidade,
            string? cod_deposito,
            string? empresa,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_deposito =
                ConvertToInt32Validation.IsValid(cod_deposito, "cod_deposito", listValidations) ?
                Convert.ToInt32(cod_deposito) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.cod_barra = cod_barra;
            this.recordKey = $"[{cnpj_emp}]|[{cod_produto}]|[{cod_deposito}]";
            this.recordXml = recordXml;
        }
    }
}
