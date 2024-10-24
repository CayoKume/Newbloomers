using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDepositos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_deposito { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_deposito { get; set; }

        [Column(TypeName = "char(1)")]
        public string? disponivel { get; set; }

        [Column(TypeName = "bit")]
        public Int32? disponivel_transferencia { get; set; }

        [Column(TypeName = "bit")]
        public Int32? disponivel_franquias { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
