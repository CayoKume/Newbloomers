using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosPromocao
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigo_promocao { get; set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "money")]
        public decimal? preco { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_inicio { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_termino { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_cadastro { get; set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; set; }

        [Column(TypeName = "int")]
        public Int32? codigo_campanha { get; set; }

        [Column(TypeName = "bit")]
        public Int32? promocao_opcional { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
