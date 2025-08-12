
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionais
    {
        public DateTime? lastupdateon { get; private set; }
        public Guid? identificador { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? transacao { get; private set; }
        public Int32? id_acoes_promocionais { get; private set; }
        public decimal? desconto_item { get; private set; }
        public Int32? quantidade { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoAcoesPromocionais() { }

        public LinxMovimentoAcoesPromocionais(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoAcoesPromocionais record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.id_acoes_promocionais = CustomConvertersExtensions.ConvertToInt32Validation(record.id_acoes_promocionais);
            this.quantidade = CustomConvertersExtensions.ConvertToInt32Validation(record.quantidade);
            this.identificador = Guid.Parse(record.identificador);
            this.desconto_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto_item);
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
