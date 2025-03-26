using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaProdutosPalavrasChavePesquisa", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosPalavrasChavePesquisa
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_b2c_palavras_chave_pesquisa_produtos { get; private set; }

        public Int32? id_b2c_palavras_chave_pesquisa { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 300, propertyName: "descricao_b2c_palavras_chave_pesquisa")]
        public string? descricao_b2c_palavras_chave_pesquisa { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosPalavrasChavePesquisa() { }

        public B2CConsultaProdutosPalavrasChavePesquisa(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_b2c_palavras_chave_pesquisa_produtos,
            string? id_b2c_palavras_chave_pesquisa,
            string? codigoproduto,
            string? timestamp,
            string? descricao_b2c_palavras_chave_pesquisa,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_palavras_chave_pesquisa_produtos =
                ConvertToInt32Validation.IsValid(id_b2c_palavras_chave_pesquisa_produtos, "id_b2c_palavras_chave_pesquisa_produtos", listValidations) ?
                Convert.ToInt32(id_b2c_palavras_chave_pesquisa_produtos) :
                0;

            this.id_b2c_palavras_chave_pesquisa =
                ConvertToInt32Validation.IsValid(id_b2c_palavras_chave_pesquisa, "id_b2c_palavras_chave_pesquisa", listValidations) ?
                Convert.ToInt32(id_b2c_palavras_chave_pesquisa) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao_b2c_palavras_chave_pesquisa = descricao_b2c_palavras_chave_pesquisa;
            this.recordXml = recordXml;
        }
    }
}
