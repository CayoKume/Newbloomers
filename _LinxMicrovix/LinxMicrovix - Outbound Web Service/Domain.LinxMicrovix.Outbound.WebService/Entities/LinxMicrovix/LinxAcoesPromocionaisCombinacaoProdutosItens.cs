using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix
{
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
            string? id_acoes_promocionais_combinacao_produtos_itens,
            string? id_combinacao_produto,
            string? codigoproduto,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_acoes_promocionais_combinacao_produtos_itens =
                id_acoes_promocionais_combinacao_produtos_itens == String.Empty ? 0
                : Convert.ToInt32(id_acoes_promocionais_combinacao_produtos_itens);

            this.id_combinacao_produto =
                id_combinacao_produto == String.Empty ? 0
                : Convert.ToInt32(id_combinacao_produto);

            this.codigoproduto =
                codigoproduto == String.Empty ? 0
                : Convert.ToInt64(codigoproduto);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
