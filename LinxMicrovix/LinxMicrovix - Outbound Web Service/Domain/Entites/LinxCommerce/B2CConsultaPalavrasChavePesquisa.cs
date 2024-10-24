using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisa
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_b2c_palavras_chave_pesquisa { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? nome_colecao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public B2CConsultaPalavrasChavePesquisa() { }

        public B2CConsultaPalavrasChavePesquisa(
            string? portal,
            string? id_b2c_palavras_chave_pesquisa,
            string? nome_colecao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_palavras_chave_pesquisa =
                id_b2c_palavras_chave_pesquisa == String.Empty ? 0
                : Convert.ToInt32(id_b2c_palavras_chave_pesquisa);

            this.nome_colecao =
                nome_colecao == String.Empty ? ""
                : nome_colecao.Substring(
                    0,
                    nome_colecao.Length > 300 ? 300
                    : nome_colecao.Length
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
