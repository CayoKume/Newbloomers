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

        [Column(TypeName = "decimal(10,2)")]
        public decimal? coeficiente_desconto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
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
                String.IsNullOrEmpty(id) ? 0
                : Convert.ToInt32(id);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.codigoproduto_associado =
                String.IsNullOrEmpty(codigoproduto_associado) ? 0
                : Convert.ToInt64(codigoproduto_associado);

            this.coeficiente_desconto =
                String.IsNullOrEmpty(coeficiente_desconto) ? 0
                : Convert.ToDecimal(coeficiente_desconto);

            this.qtde_item =
                String.IsNullOrEmpty(qtde_item) ? 0
                : Convert.ToDecimal(qtde_item);

            this.item_obrigatorio =
                String.IsNullOrEmpty(item_obrigatorio) ? 0
                : Convert.ToInt32(item_obrigatorio);

            this.timestamp =
               String.IsNullOrEmpty(timestamp) ? 0
               : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
