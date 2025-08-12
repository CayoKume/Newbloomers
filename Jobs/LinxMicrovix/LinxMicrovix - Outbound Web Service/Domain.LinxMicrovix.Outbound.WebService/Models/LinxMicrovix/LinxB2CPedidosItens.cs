
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxB2CPedidosItens
    {
        public DateTime lastupdateon { get; private set; }
        public Int32? id_pedido_item { get; private set; }
        public Int32 id_pedido { get; private set; }
        public Int64 codigoproduto { get; private set; }
        public Int32 quantidade { get; private set; }
        public decimal vl_unitario { get; private set; }
        public Int64 timestamp { get; private set; }
        public Int32 portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxB2CPedidosItens() { }

        public LinxB2CPedidosItens(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxB2CPedidosItens record, string recordXml) {
            this.lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_pedido_item = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido_item);
            this.id_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.quantidade = CustomConvertersExtensions.ConvertToInt32Validation(record.quantidade);
            this.vl_unitario = CustomConvertersExtensions.ConvertToDecimalValidation(record.vl_unitario);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.recordKey = $"[{record.id_pedido_item}]|[{record.id_pedido}]|[{record.codigoproduto}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
