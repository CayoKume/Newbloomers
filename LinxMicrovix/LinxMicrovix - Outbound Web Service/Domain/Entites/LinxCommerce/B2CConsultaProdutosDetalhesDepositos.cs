using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_deposito { get; set; }

        [Column(TypeName = "float")]
        public decimal? saldo { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        [Column(TypeName = "int")]
        public Int32? deposito { get; set; }

        [Column(TypeName = "smallint")]
        public Int32? tempo_preparacao_estoque { get; set; }
    }
}
