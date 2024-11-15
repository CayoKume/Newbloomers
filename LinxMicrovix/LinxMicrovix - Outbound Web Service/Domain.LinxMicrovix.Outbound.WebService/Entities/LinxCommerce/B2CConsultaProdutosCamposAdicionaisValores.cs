using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_campo_valor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_campo_detalhe { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisValores() { }

        public B2CConsultaProdutosCamposAdicionaisValores(
            string? id_campo_valor,
            string? codigoproduto,
            string? id_campo_detalhe,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_campo_valor =
                String.IsNullOrEmpty(id_campo_valor) ? 0
                : Convert.ToInt32(id_campo_valor);

            this.id_campo_detalhe =
                String.IsNullOrEmpty(id_campo_detalhe) ? 0
                : Convert.ToInt32(id_campo_detalhe);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
