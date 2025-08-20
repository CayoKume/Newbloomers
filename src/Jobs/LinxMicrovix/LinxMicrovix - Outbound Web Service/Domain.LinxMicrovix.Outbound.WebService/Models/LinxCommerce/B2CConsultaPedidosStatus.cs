
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPedidosStatus
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id { get; private set; }
        public Int32? id_status { get; private set; }
        public Int32? id_pedido { get; private set; }
        public DateTime? data_hora { get; private set; }
        public string? anotacao { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPedidosStatus() { }

        public B2CConsultaPedidosStatus(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPedidosStatus record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id = CustomConvertersExtensions.ConvertToInt32Validation(record.id);
            this.id_status = CustomConvertersExtensions.ConvertToInt32Validation(record.id_status);
            this.id_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido);
            this.data_hora = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_hora);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.anotacao = record.anotacao;
            this.recordKey = $"[{record.id}]|[{record.id_status}]|[{record.id_pedido}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
