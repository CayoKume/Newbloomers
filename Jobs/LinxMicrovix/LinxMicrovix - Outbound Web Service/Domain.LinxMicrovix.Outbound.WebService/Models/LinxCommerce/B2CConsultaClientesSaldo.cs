using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaClientesSaldo
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public decimal? saldo { get; private set; }

        public Int32? cod_cliente_erp { get; private set; }

        public Int32? empresa { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClientesSaldo() { }

        public B2CConsultaClientesSaldo(
            List<ValidationResult> listValidations,
            string? saldo,
            string? cod_cliente_erp,
            string? empresa,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.saldo =
                ConvertToDecimalValidation.IsValid(saldo, "saldo", listValidations) ?
                Convert.ToDecimal(saldo, new CultureInfo("en-US")) :
                0;

            this.cod_cliente_erp =
                ConvertToInt32Validation.IsValid(cod_cliente_erp, "cod_cliente_erp", listValidations) ?
                Convert.ToInt32(cod_cliente_erp) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
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
