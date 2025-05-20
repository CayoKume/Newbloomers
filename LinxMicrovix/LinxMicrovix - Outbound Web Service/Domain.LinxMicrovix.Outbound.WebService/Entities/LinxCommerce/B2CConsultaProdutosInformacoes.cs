using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosInformacoes
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_produtos_informacoes { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public string? informacoes_produto { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosInformacoes() { }

        public B2CConsultaProdutosInformacoes(
            List<ValidationResult> listValidations,
            string? id_produtos_informacoes,
            string? codigoproduto,
            string? informacoes_produto,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;


            this.id_produtos_informacoes =
                ConvertToInt32Validation.IsValid(id_produtos_informacoes, "id_produtos_informacoes", listValidations) ?
                Convert.ToInt32(id_produtos_informacoes) :
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

            this.informacoes_produto = informacoes_produto;
            this.recordXml = recordXml;
        }
    }
}
