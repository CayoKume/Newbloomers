using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaColecoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_colecao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_colecao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? marcas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaColecoes() { }

        public B2CConsultaColecoes(
            string? codigo_colecao,
            string? nome_colecao,
            string? timestamp,
            string? marcas,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_colecao =
                String.IsNullOrEmpty(codigo_colecao) ? 0
                : Convert.ToInt32(codigo_colecao);

            this.nome_colecao =
                String.IsNullOrEmpty(nome_colecao) ? ""
                : nome_colecao.Substring(
                    0,
                    nome_colecao.Length > 100 ? 100
                    : nome_colecao.Length
                );

            this.marcas =
                String.IsNullOrEmpty(marcas) ? ""
                : marcas.Substring(
                    0,
                    marcas.Length > 250 ? 250
                    : marcas.Length
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
