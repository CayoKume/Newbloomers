using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaPedidosItens
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido_item { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? vl_unitario { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPedidosItens() { }

        public B2CConsultaPedidosItens(
            string? id_pedido_item,
            string? id_pedido,
            string? codigoproduto,
            string? quantidade,
            string? vl_unitario,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido_item =
                String.IsNullOrEmpty(id_pedido_item) ? 0
                : Convert.ToInt32(id_pedido_item);

            this.id_pedido =
                String.IsNullOrEmpty(id_pedido) ? 0
                : Convert.ToInt32(id_pedido);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.quantidade =
                String.IsNullOrEmpty(quantidade) ? 0
                : Convert.ToInt32(quantidade);

            this.vl_unitario =
                String.IsNullOrEmpty(vl_unitario) ? 0
                : Convert.ToDecimal(vl_unitario);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
