using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaVendedores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_vendedor { get; set; }

        [Column(TypeName = "money")]
        public decimal? comissao_produtos { get; set; }

        [Column(TypeName = "money")]
        public decimal? comissao_servicos { get; set; }

        [Column(TypeName = "char(1)")]
        public string? tipo { get; set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; set; }

        [Column(TypeName = "bit")]
        public Int32? comissionado { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
