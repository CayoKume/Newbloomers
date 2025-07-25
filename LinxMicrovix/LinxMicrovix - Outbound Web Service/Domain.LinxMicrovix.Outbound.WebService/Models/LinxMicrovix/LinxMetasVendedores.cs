using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMetasVendedores
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_meta { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao_meta")]
        public string? descricao_meta { get; private set; }

        public DateTime? data_inicial_meta { get; private set; }

        public DateTime? data_final_meta { get; private set; }

        public decimal? valor_meta_loja { get; private set; }

        public decimal? valor_meta_vendedor { get; private set; }

        public Int32? cod_vendedor { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMetasVendedores() { }

        public LinxMetasVendedores(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_meta,
            string? descricao_meta,
            string? data_inicial_meta,
            string? data_final_meta,
            string? valor_meta_loja,
            string? valor_meta_vendedor,
            string? cod_vendedor,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_meta =
                ConvertToInt32Validation.IsValid(id_meta, "id_meta", listValidations) ?
                Convert.ToInt32(id_meta) :
                0;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.data_inicial_meta =
               ConvertToDateTimeValidation.IsValid(data_inicial_meta, "data_inicial_meta", listValidations) ?
               Convert.ToDateTime(data_inicial_meta) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.valor_meta_loja =
                ConvertToDecimalValidation.IsValid(valor_meta_loja, "valor_meta_loja", listValidations) ?
                Convert.ToDecimal(valor_meta_loja, new CultureInfo("en-US")) :
                0;

            this.data_final_meta =
               ConvertToDateTimeValidation.IsValid(data_final_meta, "data_final_meta", listValidations) ?
               Convert.ToDateTime(data_final_meta) :
               new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.valor_meta_vendedor =
                ConvertToDecimalValidation.IsValid(valor_meta_vendedor, "valor_meta_vendedor", listValidations) ?
                Convert.ToDecimal(valor_meta_vendedor, new CultureInfo("en-US")) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.descricao_meta = descricao_meta;
        }
    }
}
