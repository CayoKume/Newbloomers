using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesia
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime lastupdateon { get; private set; }

        public Int32? id_acoes_promocionais_produtos_cortesia { get; private set; }

        public Int32? id_acoes_promocionais { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int32? id_combinacao_produto { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxAcoesPromocionaisProdutosCortesia() { }

        public LinxAcoesPromocionaisProdutosCortesia(
            List<ValidationResult> listValidations,
            string? id_acoes_promocionais_produtos_cortesia,
            string? id_acoes_promocionais,
            string? codigoproduto,
            string? id_combinacao_produto,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_acoes_promocionais_produtos_cortesia =
                ConvertToInt32Validation.IsValid(id_acoes_promocionais_produtos_cortesia, "id_acoes_promocionais_produtos_cortesia", listValidations) ?
                Convert.ToInt32(id_acoes_promocionais_produtos_cortesia) :
                0;

            this.id_acoes_promocionais =
                ConvertToInt32Validation.IsValid(id_acoes_promocionais, "id_acoes_promocionais", listValidations) ?
                Convert.ToInt32(id_acoes_promocionais) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.id_combinacao_produto =
                ConvertToInt32Validation.IsValid(id_combinacao_produto, "id_combinacao_produto", listValidations) ?
                Convert.ToInt32(id_combinacao_produto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
