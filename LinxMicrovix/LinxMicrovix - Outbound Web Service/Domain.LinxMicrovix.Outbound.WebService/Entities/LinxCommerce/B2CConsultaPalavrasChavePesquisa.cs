using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaPalavrasChavePesquisa", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPalavrasChavePesquisa
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_b2c_palavras_chave_pesquisa { get; private set; }

        [LengthValidation(length: 300, propertyName: "nome_colecao")]
        public string? nome_colecao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPalavrasChavePesquisa() { }

        public B2CConsultaPalavrasChavePesquisa(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_b2c_palavras_chave_pesquisa,
            string? nome_colecao,
            string? timestamp,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_palavras_chave_pesquisa =
                ConvertToInt32Validation.IsValid(id_b2c_palavras_chave_pesquisa, "id_b2c_palavras_chave_pesquisa", listValidations) ?
                Convert.ToInt32(id_b2c_palavras_chave_pesquisa) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_colecao = nome_colecao;
            this.recordXml = recordXml;
        }
    }
}
