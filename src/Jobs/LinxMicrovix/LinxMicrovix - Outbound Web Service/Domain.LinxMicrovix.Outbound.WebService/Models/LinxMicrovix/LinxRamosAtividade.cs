
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxRamosAtividade
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_ramo_atividade { get; private set; }
        public Int32? portal { get; private set; }
        public string? nome_ramo_atividade { get; private set; }
        public string? codigo_ramo_atividade { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxRamosAtividade() { }

        public LinxRamosAtividade(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxRamosAtividade record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_ramo_atividade = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ramo_atividade);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.nome_ramo_atividade = record.nome_ramo_atividade;
            this.codigo_ramo_atividade = record.codigo_ramo_atividade;
        }
    }
}
