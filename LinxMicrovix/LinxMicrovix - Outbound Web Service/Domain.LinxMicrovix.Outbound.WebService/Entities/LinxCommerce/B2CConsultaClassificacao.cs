using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
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
                String.IsNullOrEmpty(codigo_classificacao) ? 0
                : Convert.ToInt64(codigo_classificacao);

            this.nome_classificacao =
                String.IsNullOrEmpty(nome_classificacao) ? ""
                : nome_classificacao.Substring(
                    0,
                    nome_classificacao.Length > 50 ? 50
                    : nome_classificacao.Length
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