using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxComissoesVendedores
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? vendedor { get; private set; }

        public Int32? empresa { get; private set; }

        public DateTime? data_origem { get; private set; }

        public decimal? valor_base { get; private set; }

        public decimal? valor_comissao { get; private set; }

        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }

        [LengthValidation(length: 1, propertyName: "disponivel")]
        public string? disponivel { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxComissoesVendedores() { }

        public LinxComissoesVendedores(
            List<ValidationResult> listValidations,
            string? vendedor,
            string? empresa,
            string? data_origem,
            string? valor_base,
            string? valor_comissao,
            string? cancelado,
            string? disponivel,
            string? timestamp
        )
        {
            this.vendedor =
                ConvertToInt32Validation.IsValid(vendedor, "vendedor", listValidations) ?
                Convert.ToInt32(vendedor) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.valor_base =
                ConvertToDecimalValidation.IsValid(valor_base, "valor_base", listValidations) ?
                Convert.ToDecimal(valor_base, new CultureInfo("en-US")) :
                0;

            this.valor_comissao =
                ConvertToDecimalValidation.IsValid(valor_comissao, "valor_comissao", listValidations) ?
                Convert.ToDecimal(valor_comissao, new CultureInfo("en-US")) :
                0;

            this.data_origem =
                ConvertToDateTimeValidation.IsValid(data_origem, "data_origem", listValidations) ?
                Convert.ToDateTime(data_origem) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cancelado = cancelado;
            this.disponivel = disponivel;
        }
    }
}
