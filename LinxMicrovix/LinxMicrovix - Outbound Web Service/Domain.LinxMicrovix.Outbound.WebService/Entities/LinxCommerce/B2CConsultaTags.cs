using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaTags
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido_item { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        public B2CConsultaTags() { }

        public B2CConsultaTags(
            string? portal,
            string? id_pedido_item,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.descricao =
                String.IsNullOrEmpty(descricao) ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 300 ? 300
                    : descricao.Length
                );

            this.id_pedido_item =
                String.IsNullOrEmpty(id_pedido_item) ? 0
                : Convert.ToInt32(id_pedido_item);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
