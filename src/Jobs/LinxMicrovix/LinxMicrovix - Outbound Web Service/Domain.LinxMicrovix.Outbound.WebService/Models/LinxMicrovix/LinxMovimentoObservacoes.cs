
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoObservacoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_obs { get; private set; }
        public Int32? portal { get; private set; }
        public string? titulo_obs { get; private set; }
        public string? descricao_obs { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoObservacoes() { }

        public LinxMovimentoObservacoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoObservacoes record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_obs = CustomConvertersExtensions.ConvertToInt32Validation(record.id_obs);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.titulo_obs = record.titulo_obs;
            this.descricao_obs = record.descricao_obs;
        }
    }
}
