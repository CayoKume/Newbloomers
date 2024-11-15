using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_campo { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? ordem { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? legenda { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisNomes() { }

        public B2CConsultaProdutosCamposAdicionaisNomes(
            string? id_campo,
            string? ordem,
            string? legenda,
            string? tipo,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_campo =
                String.IsNullOrEmpty(id_campo) ? 0
                : Convert.ToInt32(id_campo);

            this.ordem =
                String.IsNullOrEmpty(ordem) ? 0
                : Convert.ToInt32(ordem);

            this.legenda =
                String.IsNullOrEmpty(legenda) ? ""
                : legenda.Substring(
                    0,
                    legenda.Length > 30 ? 30
                    : legenda.Length
                );

            this.tipo =
                String.IsNullOrEmpty(tipo) ? ""
                : tipo.Substring(
                    0,
                    tipo.Length > 1 ? 1
                    : tipo.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
