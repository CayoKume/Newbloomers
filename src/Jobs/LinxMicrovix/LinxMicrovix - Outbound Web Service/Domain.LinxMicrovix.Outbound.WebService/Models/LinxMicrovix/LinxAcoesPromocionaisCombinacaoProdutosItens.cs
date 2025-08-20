
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAcoesPromocionaisCombinacaoProdutosItens
    {
        public DateTime lastupdateon { get; private set; }
        public Int32? id_acoes_promocionais_combinacao_produtos_itens { get; private set; }
        public Int32? id_combinacao_produto { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxAcoesPromocionaisCombinacaoProdutosItens() { }

        public LinxAcoesPromocionaisCombinacaoProdutosItens(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxAcoesPromocionaisCombinacaoProdutosItens record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_acoes_promocionais_combinacao_produtos_itens = CustomConvertersExtensions.ConvertToInt32Validation(record.id_acoes_promocionais_combinacao_produtos_itens);
            this.id_combinacao_produto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_combinacao_produto);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
        }
    }
}
