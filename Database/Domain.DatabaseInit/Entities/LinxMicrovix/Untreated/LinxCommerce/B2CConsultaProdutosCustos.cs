using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosCustos", Schema = "untreated")]
    public class B2CConsultaProdutosCustos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_produtos_custos { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? custoicms1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? ipi1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? markup { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? customedio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? frete1 { get; private set; }

        [Column(TypeName = "int")]
        public string? precisao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? precominimo { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? custoliquido { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? precovenda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? custototal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? precocompra { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
