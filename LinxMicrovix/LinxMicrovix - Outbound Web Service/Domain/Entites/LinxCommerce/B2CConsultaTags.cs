using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
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
    }
}
