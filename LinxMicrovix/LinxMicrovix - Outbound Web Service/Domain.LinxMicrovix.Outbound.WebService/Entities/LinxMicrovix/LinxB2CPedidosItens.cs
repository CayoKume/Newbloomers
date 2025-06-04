using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxB2CPedidosItens
    {
        [SkipProperty]
        public Int32 id { get; set; }

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

        public LinxB2CPedidosItens(
            List<ValidationResult> listValidations,
            string? id_pedido_item,
            string? id_pedido,
            string? codigoproduto,
            string? quantidade,
            string? vl_unitario,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            this.lastupdateon = DateTime.Now;

            this.id_pedido_item =
                ConvertToInt32Validation.IsValid(id_pedido_item, "id_pedido_item", listValidations) ?
                Convert.ToInt32(id_pedido_item) :
                0;

            this.id_pedido =
                ConvertToInt32Validation.IsValid(id_pedido, "id_pedido", listValidations) ?
                Convert.ToInt32(id_pedido) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.quantidade =
                ConvertToInt32Validation.IsValid(quantidade, "porquantidadetal", listValidations) ?
                Convert.ToInt32(quantidade) :
                0;

            this.vl_unitario =
                ConvertToDecimalValidation.IsValid(vl_unitario, "vl_unitario", listValidations) ?
                Convert.ToDecimal(vl_unitario, new CultureInfo("en-US")) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.recordKey = $"[{id_pedido_item}]|[{id_pedido}]|[{codigoproduto}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
