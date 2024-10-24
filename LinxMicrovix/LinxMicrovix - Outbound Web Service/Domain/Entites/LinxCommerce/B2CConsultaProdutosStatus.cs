using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; set; }

        [Column(TypeName = "bit")]
        public Int32? b2c { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
