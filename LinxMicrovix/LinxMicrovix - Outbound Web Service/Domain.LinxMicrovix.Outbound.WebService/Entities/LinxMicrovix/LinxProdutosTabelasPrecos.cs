using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxProdutosTabelasPrecos
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? cod_produto { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_tabela { get; private set; }

        public decimal? precovenda { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosTabelasPrecos() { }

        public LinxProdutosTabelasPrecos(
            List<ValidationResult> listValidations,
            string? cod_produto,
            string? portal,
            string? cnpj_emp,
            string? id_tabela,
            string? precovenda,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tabela =
                ConvertToInt32Validation.IsValid(id_tabela, "id_tabela", listValidations) ?
                Convert.ToInt32(id_tabela) :
                0;

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

            this.precovenda =
                ConvertToDecimalValidation.IsValid(precovenda, "precovenda", listValidations) ?
                Convert.ToDecimal(precovenda, new CultureInfo("en-US")) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.recordKey = $"[{cnpj_emp}]|[{cod_produto}]|[{id_tabela}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
