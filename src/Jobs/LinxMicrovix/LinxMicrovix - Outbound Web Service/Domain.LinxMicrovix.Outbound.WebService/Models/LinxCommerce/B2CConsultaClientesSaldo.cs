
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaClientesSaldo
    {
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesSaldo record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.saldo = CustomConvertersExtensions.ConvertToDecimalValidation(record.saldo);
            this.cod_cliente_erp = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_erp);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.recordXml = recordXml;
        }
    }
}
