using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix
{
    public class LinxB2CPedidosItens
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32 id_pedido_item { get; private set; }

        [Column(TypeName = "int")]
        public Int32 id_pedido { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64 codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32 quantidade { get; private set; }

        [Column(TypeName = "decimeal(10,2)")]
        public decimal vl_unitario { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64 timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32 portal { get; private set; }

        public LinxB2CPedidosItens() { }

        public LinxB2CPedidosItens(
            string? id_pedido_item,
            string? id_pedido,
            string? codigoproduto,
            string? quantidade,
            string? vl_unitario,
            string? timestamp,
            string? portal
        )
        {
            this.lastupdateon = DateTime.Now;

            this.id_pedido_item =
                id_pedido_item == String.Empty ? 0
                : Convert.ToInt32(id_pedido_item);

            this.id_pedido =
                id_pedido == String.Empty ? 0
                : Convert.ToInt32(id_pedido);

            this.codigoproduto =
                codigoproduto == String.Empty ? 0
                : Convert.ToInt64(codigoproduto);

            this.quantidade =
               quantidade == String.Empty ? 0
               : Convert.ToInt32(quantidade);

            this.vl_unitario =
               vl_unitario == String.Empty ? 0
               : Convert.ToDecimal(vl_unitario);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
