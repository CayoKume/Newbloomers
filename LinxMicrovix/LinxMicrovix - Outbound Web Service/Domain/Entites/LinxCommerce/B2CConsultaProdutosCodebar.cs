using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCodebar
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? codebar { get; set; }

        [Column(TypeName = "int")]
        public Int32? id_produtos_codebar { get; set; }

        [Column(TypeName = "bit")]
        public Int32? principal { get; set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? tipo_codebar { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
