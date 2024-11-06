using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesia
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_acoes_promocionais_produtos_cortesia { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_acoes_promocionais { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_combinacao_produto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxAcoesPromocionaisProdutosCortesia() { }

        public LinxAcoesPromocionaisProdutosCortesia(
            string? id_acoes_promocionais_produtos_cortesia,
            string? id_acoes_promocionais,
            string? codigoproduto,
            string? id_combinacao_produto,
            string? portal,
            string? timestamp
        )
        {
            this.lastupdateon = DateTime.Now;

            this.id_acoes_promocionais_produtos_cortesia =
                id_acoes_promocionais_produtos_cortesia == String.Empty ? 0
                : Convert.ToInt32(id_acoes_promocionais_produtos_cortesia);
            
            this.id_acoes_promocionais =
                id_acoes_promocionais == String.Empty ? 0
                : Convert.ToInt32(id_acoes_promocionais);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);

            this.codigoproduto =
                codigoproduto == String.Empty ? 0
                : Convert.ToInt64(codigoproduto);

            this.id_combinacao_produto =
                id_combinacao_produto == String.Empty ? 0
                : Convert.ToInt32(id_combinacao_produto);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
