
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaTipo
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDevolucaoRemanejoFabricaTipo() { }

        public LinxDevolucaoRemanejoFabricaTipo(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxDevolucaoRemanejoFabricaTipo record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_devolucao_remanejo_fabrica_tipo = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica_tipo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
