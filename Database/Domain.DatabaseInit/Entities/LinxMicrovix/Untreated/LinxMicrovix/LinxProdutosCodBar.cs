using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxProdutosCodBar", Schema = "untreated")]
    public class LinxProdutosCodBar
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? cod_barra { get; set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; set; }
    }
}
