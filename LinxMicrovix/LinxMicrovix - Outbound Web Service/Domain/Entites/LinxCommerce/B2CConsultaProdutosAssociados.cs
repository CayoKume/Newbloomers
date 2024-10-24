using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosAssociados
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto_associado { get; private set; }

        [Column(TypeName = "float")]
        public decimal? coeficiente_desconto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "float")]
        public decimal? qtde_item { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? item_obrigatorio { get; private set; }

        public B2CConsultaProdutosAssociados() { }

        public B2CConsultaProdutosAssociados(
            string? id,
            string? codigoproduto,
            string? codigoproduto_associado,
            string? coeficiente_desconto,
            string? timestamp,
            string? portal,
            string? qtde_item,
            string? item_obrigatorio
        )
        {
            lastupdateon = DateTime.Now;

            this.id =
                id == String.Empty ? 0
                : Convert.ToInt32(id);

            this.codigoproduto =
                codigoproduto == String.Empty ? 0
                : Convert.ToInt64(codigoproduto);

            this.codigoproduto_associado =
                codigoproduto_associado == String.Empty ? 0
                : Convert.ToInt64(codigoproduto_associado);

            this.coeficiente_desconto =
                coeficiente_desconto == String.Empty ? 0
                : Convert.ToDecimal(coeficiente_desconto);

            this.qtde_item =
                qtde_item == String.Empty ? 0
                : Convert.ToDecimal(qtde_item);

            this.item_obrigatorio =
                item_obrigatorio == String.Empty ? 0
                : Convert.ToInt32(item_obrigatorio);

            this.timestamp =
               timestamp == String.Empty ? 0
               : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
