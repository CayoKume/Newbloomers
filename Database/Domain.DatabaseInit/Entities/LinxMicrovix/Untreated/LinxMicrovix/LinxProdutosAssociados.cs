using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxProdutosAssociados", Schema = "untreated")]
    public class LinxProdutosAssociados
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto_associado { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto_origem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? coeficiente_desconto { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_item { get; private set; }

        [Column(TypeName = "bit")]
        public string? item_obrigatorio { get; private set; }
    }
}
