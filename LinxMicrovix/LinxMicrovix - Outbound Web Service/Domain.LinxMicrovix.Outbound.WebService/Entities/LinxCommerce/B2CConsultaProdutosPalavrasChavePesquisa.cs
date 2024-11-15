using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisa
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_b2c_palavras_chave_pesquisa_produtos { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_b2c_palavras_chave_pesquisa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao_b2c_palavras_chave_pesquisa { get; private set; }

        public B2CConsultaProdutosPalavrasChavePesquisa() { }

        public B2CConsultaProdutosPalavrasChavePesquisa(
            string? portal,
            string? id_b2c_palavras_chave_pesquisa_produtos,
            string? id_b2c_palavras_chave_pesquisa,
            string? codigoproduto,
            string? timestamp,
            string? descricao_b2c_palavras_chave_pesquisa
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_palavras_chave_pesquisa_produtos =
                String.IsNullOrEmpty(id_b2c_palavras_chave_pesquisa_produtos) ? 0
                : Convert.ToInt32(id_b2c_palavras_chave_pesquisa_produtos);

            this.id_b2c_palavras_chave_pesquisa =
                String.IsNullOrEmpty(id_b2c_palavras_chave_pesquisa) ? 0
                : Convert.ToInt32(id_b2c_palavras_chave_pesquisa);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.descricao_b2c_palavras_chave_pesquisa =
                String.IsNullOrEmpty(descricao_b2c_palavras_chave_pesquisa) ? ""
                : descricao_b2c_palavras_chave_pesquisa.Substring(
                    0,
                    descricao_b2c_palavras_chave_pesquisa.Length > 300 ? 300
                    : descricao_b2c_palavras_chave_pesquisa.Length
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
