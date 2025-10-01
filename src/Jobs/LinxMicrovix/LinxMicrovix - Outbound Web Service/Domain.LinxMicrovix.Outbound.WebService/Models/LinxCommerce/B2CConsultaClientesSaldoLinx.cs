
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinx
    {
        public Int32 id { get; set; }
        public DateTime? lastupdateon { get; private set; }
        public Int32? cod_cliente_erp { get; private set; }
        public Int32? cod_cliente_b2c { get; private set; }
        public Int32? empresa { get; private set; }
        public decimal? valor { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClientesSaldoLinx() { }

        public B2CConsultaClientesSaldoLinx(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesSaldoLinx record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.cod_cliente_b2c = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_b2c);
            this.cod_cliente_erp = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_erp);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.recordXml = recordXml;
        }
    }
}
