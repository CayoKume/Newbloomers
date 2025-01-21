using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxAcoesPromocionaisCombinacaoProdutosItens", Schema = "untreated")]
    public class LinxAcoesPromocionaisCombinacaoProdutosItens
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_acoes_promocionais_combinacao_produtos_itens { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_combinacao_produto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxAcoesPromocionaisCombinacaoProdutosItens() { }

        public LinxAcoesPromocionaisCombinacaoProdutosItens(
            List<ValidationResult> listValidations,
            string? id_acoes_promocionais_combinacao_produtos_itens,
            string? id_combinacao_produto,
            string? codigoproduto,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_acoes_promocionais_combinacao_produtos_itens =
                ConvertToInt32Validation.IsValid(id_acoes_promocionais_combinacao_produtos_itens, "id_acoes_promocionais_combinacao_produtos_itens", listValidations) ?
                Convert.ToInt32(id_acoes_promocionais_combinacao_produtos_itens) :
                0;

            this.id_combinacao_produto =
                ConvertToInt32Validation.IsValid(id_combinacao_produto, "id_combinacao_produto", listValidations) ?
                Convert.ToInt32(id_combinacao_produto) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
