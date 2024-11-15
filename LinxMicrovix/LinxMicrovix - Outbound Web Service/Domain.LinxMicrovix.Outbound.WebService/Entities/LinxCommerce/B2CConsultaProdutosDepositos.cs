using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDepositos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_deposito { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_deposito { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? disponivel { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? disponivel_transferencia { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? disponivel_franquias { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosDepositos() { }

        public B2CConsultaProdutosDepositos(
            string? id_deposito,
            string? nome_deposito,
            string? disponivel,
            string? disponivel_transferencia,
            string? disponivel_franquias,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_deposito =
                String.IsNullOrEmpty(id_deposito) ? 0
                : Convert.ToInt32(id_deposito);

            this.nome_deposito =
                String.IsNullOrEmpty(nome_deposito) ? ""
                : nome_deposito.Substring(
                    0,
                    nome_deposito.Length > 50 ? 50
                    : nome_deposito.Length
                );

            this.disponivel =
                String.IsNullOrEmpty(disponivel) ? ""
                : disponivel.Substring(
                    0,
                    disponivel.Length > 1 ? 1
                    : disponivel.Length
                );

            this.disponivel_transferencia =
                String.IsNullOrEmpty(disponivel_transferencia) ? 0
                : Convert.ToInt32(disponivel_transferencia);

            this.disponivel_franquias =
                String.IsNullOrEmpty(disponivel_franquias) ? 0
                : Convert.ToInt32(disponivel_franquias);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
