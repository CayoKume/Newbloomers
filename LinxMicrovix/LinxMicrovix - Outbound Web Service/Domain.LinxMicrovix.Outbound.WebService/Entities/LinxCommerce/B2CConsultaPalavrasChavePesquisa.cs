using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
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
        [LengthValidation(length: 300, propertyName: "nome_colecao")]
        public string? nome_colecao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public B2CConsultaPalavrasChavePesquisa() { }

        public B2CConsultaPalavrasChavePesquisa(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_b2c_palavras_chave_pesquisa,
            string? nome_colecao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_palavras_chave_pesquisa =
                String.IsNullOrEmpty(id_b2c_palavras_chave_pesquisa) ? 0
                : Convert.ToInt32(id_b2c_palavras_chave_pesquisa);

            this.nome_colecao =
                String.IsNullOrEmpty(nome_colecao) ? ""
                : nome_colecao.Substring(
                    0,
                    nome_colecao.Length > 300 ? 300
                    : nome_colecao.Length
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
