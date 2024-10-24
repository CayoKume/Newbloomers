using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCustos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_produtos_custos { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; set; }

        [Column(TypeName = "float")]
        public decimal? custoicms1 { get; set; }

        [Column(TypeName = "float")]
        public decimal? ipi1 { get; set; }

        [Column(TypeName = "float")]
        public decimal? markup { get; set; }

        [Column(TypeName = "float")]
        public decimal? customedio { get; set; }

        [Column(TypeName = "float")]
        public decimal? frete1 { get; set; }

        [Column(TypeName = "int")]
        public Int32? precisao { get; set; }

        [Column(TypeName = "float")]
        public decimal? precominimo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_update { get; set; }

        [Column(TypeName = "float")]
        public decimal? custoliquido { get; set; }

        [Column(TypeName = "float")]
        public decimal? precovenda { get; set; }

        [Column(TypeName = "float")]
        public decimal? custototal { get; set; }

        [Column(TypeName = "float")]
        public decimal? precocompra { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
