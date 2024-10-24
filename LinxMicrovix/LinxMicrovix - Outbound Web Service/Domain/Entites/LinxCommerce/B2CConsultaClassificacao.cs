using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaClassificacao
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int64? codigo_classificacao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_classificacao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClassificacao() { }

        public B2CConsultaClassificacao(
            string? codigo_classificacao,
            string? nome_classificacao,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_classificacao =
                codigo_classificacao == String.Empty ? 0
                : Convert.ToInt64(codigo_classificacao);

            this.nome_classificacao =
                nome_classificacao == String.Empty ? ""
                : nome_classificacao.Substring(
                    0,
                    nome_classificacao.Length > 50 ? 50
                    : nome_classificacao.Length
                );

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);

        }
    }
}