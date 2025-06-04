using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxAcoesPromocionaisCombinacaoProdutosItens", Schema = "untreated")]
    public class LinxAcoesPromocionaisCombinacaoProdutosItens
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_acoes_promocionais_combinacao_produtos_itens { get; private set; }

        [Column(TypeName = "int")]
        public string? id_combinacao_produto { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
