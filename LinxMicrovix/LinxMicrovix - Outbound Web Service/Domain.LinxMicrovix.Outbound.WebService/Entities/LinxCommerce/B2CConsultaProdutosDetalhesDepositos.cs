using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_deposito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? saldo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "int")]
        public Int32? deposito { get; private set; }

        [Column(TypeName = "smallint")]
        public Int32? tempo_preparacao_estoque { get; private set; }

        public B2CConsultaProdutosDetalhesDepositos() { }

        public B2CConsultaProdutosDetalhesDepositos(
            string? codigoproduto,
            string? empresa,
            string? id_deposito,
            string? saldo,
            string? timestamp,
            string? portal,
            string? deposito,
            string? tempo_preparacao_estoque
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.id_deposito =
                String.IsNullOrEmpty(id_deposito) ? 0
                : Convert.ToInt32(id_deposito);

            this.saldo =
                String.IsNullOrEmpty(saldo) ? 0
                : Convert.ToDecimal(saldo);

            this.deposito =
                String.IsNullOrEmpty(deposito) ? 0
                : Convert.ToInt32(deposito);

            this.tempo_preparacao_estoque =
                String.IsNullOrEmpty(tempo_preparacao_estoque) ? 0
                : Convert.ToInt32(tempo_preparacao_estoque);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
