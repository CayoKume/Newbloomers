using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaEspessuras
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_espessura { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_espessura { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaEspessuras() { }

        public B2CConsultaEspessuras(
            string? codigo_espessura,
            string? nome_espessura,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_espessura =
                String.IsNullOrEmpty(codigo_espessura) ? 0
                : Convert.ToInt32(codigo_espessura);

            this.nome_espessura =
                String.IsNullOrEmpty(nome_espessura) ? ""
                : nome_espessura.Substring(
                    0,
                    nome_espessura.Length > 100 ? 100
                    : nome_espessura.Length
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
