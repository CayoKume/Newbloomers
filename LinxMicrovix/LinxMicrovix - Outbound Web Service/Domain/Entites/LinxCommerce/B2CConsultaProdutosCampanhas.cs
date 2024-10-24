using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCampanhas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_campanha { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_campanha { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? vigencia_inicio { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? vigencia_fim { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosCampanhas() { }

        public B2CConsultaProdutosCampanhas(
            string? codigo_campanha,
            string? nome_campanha,
            string? vigencia_inicio,
            string? vigencia_fim,
            string? observacao,
            string? ativo,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_campanha =
                codigo_campanha == String.Empty ? 0
                : Convert.ToInt32(codigo_campanha);

            this.nome_campanha =
                nome_campanha == String.Empty ? ""
                : nome_campanha.Substring(
                    0,
                    nome_campanha.Length > 60 ? 60
                    : nome_campanha.Length
                );

            this.vigencia_inicio =
                vigencia_inicio == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(vigencia_inicio);

            this.vigencia_fim =
                vigencia_fim == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(vigencia_fim);

            this.observacao =
                observacao == String.Empty ? ""
                : observacao;

            this.ativo =
                ativo == String.Empty ? 0
                : Convert.ToInt32(ativo);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
