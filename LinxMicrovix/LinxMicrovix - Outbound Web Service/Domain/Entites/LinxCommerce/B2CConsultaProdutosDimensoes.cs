using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDimensoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? altura { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? comprimento { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? largura { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
