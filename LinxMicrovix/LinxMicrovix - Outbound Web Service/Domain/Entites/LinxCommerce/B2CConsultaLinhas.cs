using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaLinhas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_linha { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? nome_linha { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? setores { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaLinhas() { }

        public B2CConsultaLinhas(
            string? codigo_linha,
            string? nome_linha,
            string? timestamp,
            string? setores,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_linha =
                String.IsNullOrEmpty(codigo_linha) ? 0
                : Convert.ToInt32(codigo_linha);

            this.nome_linha =
                String.IsNullOrEmpty(nome_linha) ? ""
                : nome_linha.Substring(
                    0,
                    nome_linha.Length > 30 ? 30
                    : nome_linha.Length
                );

            this.setores =
                String.IsNullOrEmpty(setores) ? ""
                : setores.Substring(
                    0,
                    setores.Length > 250 ? 250
                    : setores.Length
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
