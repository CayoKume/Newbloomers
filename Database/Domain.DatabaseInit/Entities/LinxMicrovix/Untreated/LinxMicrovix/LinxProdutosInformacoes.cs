using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxProdutosInformacoes", Schema = "untreated")]
    public class LinxProdutosInformacoes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? informacoes_produto { get; set; }
    }
}
