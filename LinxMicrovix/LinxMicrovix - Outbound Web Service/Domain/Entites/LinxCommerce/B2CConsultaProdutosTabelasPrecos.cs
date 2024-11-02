using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_prod_tab_preco { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_tabela { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? precovenda { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosTabelasPrecos() { }

        public B2CConsultaProdutosTabelasPrecos(
            string? id_prod_tab_preco,
            string? id_tabela,
            string? codigoproduto,
            string? precovenda,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_prod_tab_preco =
                String.IsNullOrEmpty(id_prod_tab_preco) ? 0
                : Convert.ToInt32(id_prod_tab_preco);

            this.id_tabela =
                String.IsNullOrEmpty(id_tabela) ? 0
                : Convert.ToInt32(id_tabela);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.precovenda =
                String.IsNullOrEmpty(precovenda) ? 0
                : Convert.ToDecimal(precovenda);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
