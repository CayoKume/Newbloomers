using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDetalhes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_prod_det { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; set; }

        [Column(TypeName = "float")]
        public decimal? saldo { get; set; }

        [Column(TypeName = "bit")]
        public Int32? controla_lote { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? nomeproduto_alternativo { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? localizacao { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        [Column(TypeName = "smallint")]
        public Int32? tempo_preparacao_estoque { get; set; }
    }
}
