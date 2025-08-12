
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRespostaVenda
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_resposta_venda { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao_resposta { get; private set; }
        public Int32? id_pergunta_venda { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRespostaVenda() { }

        public LinxRespostaVenda(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxRespostaVenda record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_resposta_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_resposta_venda);
            this.id_pergunta_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pergunta_venda);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao_resposta = record.descricao_resposta;
        }
    }
}
