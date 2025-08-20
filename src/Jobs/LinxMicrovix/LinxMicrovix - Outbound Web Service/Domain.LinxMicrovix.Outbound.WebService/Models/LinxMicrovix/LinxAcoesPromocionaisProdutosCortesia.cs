
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesia
    {
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

        public LinxAcoesPromocionaisProdutosCortesia(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxAcoesPromocionaisProdutosCortesia record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_acoes_promocionais_produtos_cortesia = CustomConvertersExtensions.ConvertToInt32Validation(record.id_acoes_promocionais_produtos_cortesia);
            this.id_acoes_promocionais = CustomConvertersExtensions.ConvertToInt32Validation(record.id_acoes_promocionais);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.id_combinacao_produto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_combinacao_produto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
        }
    }
}
