using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosAssociados", Schema = "untreated")]
    public class B2CConsultaProdutosAssociados
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto_associado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? coeficiente_desconto { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_item { get; private set; }

        [Column(TypeName = "bit")]
        public string? item_obrigatorio { get; private set; }
    }
}
