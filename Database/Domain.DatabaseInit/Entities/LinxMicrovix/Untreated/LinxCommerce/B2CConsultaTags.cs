using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaTags", Schema = "untreated")]
    public class B2CConsultaTags
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; set; }

        [Column(TypeName = "int")]
        public string? portal { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_pedido_item { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao { get; set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; set; }
    }
}
