
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPedidosIdentificador
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Guid? identificador { get; private set; }
        public Int32? id_venda { get; private set; }
        public string? order_id { get; private set; }
        public Int32? id_cliente { get; private set; }
        public decimal? valor_frete { get; private set; }
        public DateTime? data_origem { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPedidosIdentificador() { }

        public B2CConsultaPedidosIdentificador(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPedidosIdentificador record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_venda);
            this.id_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cliente);
            this.data_origem = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_origem);
            this.valor_frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_frete);
            this.identificador = String.IsNullOrEmpty(record.identificador) ? null : Guid.Parse(record.identificador);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt32Validation(record.timestamp);

            this.order_id = record.order_id;
            this.recordKey = $"[{record.identificador}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
