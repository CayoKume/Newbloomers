
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPerguntaVenda
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_pergunta_venda { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao_pergunta { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPerguntaVenda() { }

        public LinxPerguntaVenda(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPerguntaVenda record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_pergunta_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pergunta_venda);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao_pergunta = record.descricao_pergunta;
        }
    }
}
