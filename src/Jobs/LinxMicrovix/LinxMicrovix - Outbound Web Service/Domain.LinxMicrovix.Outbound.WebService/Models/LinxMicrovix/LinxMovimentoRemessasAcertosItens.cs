
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosItens
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_remessas_acertos { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? transacao { get; private set; }
        public decimal? qtde_total { get; private set; }
        public Int32? id_remessa_operacoes { get; private set; }
        public Int32? id_remessas_itens { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoRemessasAcertosItens() { }

        public LinxMovimentoRemessasAcertosItens(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoRemessasAcertosItens record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_remessas_acertos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas_acertos);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.id_remessa_operacoes = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessa_operacoes);
            this.id_remessas_itens = CustomConvertersExtensions.ConvertToInt32Validation(record.id_remessas_itens);
            this.qtde_total = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_total);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            
        }
    }
}
