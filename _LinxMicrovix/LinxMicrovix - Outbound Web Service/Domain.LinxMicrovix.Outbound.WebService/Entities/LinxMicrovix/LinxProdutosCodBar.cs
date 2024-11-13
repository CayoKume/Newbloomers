using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxMicrovix
{
    public class LinxProdutosCodBar
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_produto { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? cod_barra { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        public LinxProdutosCodBar() { }

        public LinxProdutosCodBar(
            string? portal,
            string? cod_produto,
            string? cod_barra,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_produto =
                String.IsNullOrEmpty(cod_produto) ? 0
                : Convert.ToInt64(cod_produto);

            this.cod_barra =
                String.IsNullOrEmpty(cod_barra) ? ""
                : cod_barra.Substring(
                    0,
                    cod_barra.Length > 20 ? 20
                    : cod_barra.Length
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
