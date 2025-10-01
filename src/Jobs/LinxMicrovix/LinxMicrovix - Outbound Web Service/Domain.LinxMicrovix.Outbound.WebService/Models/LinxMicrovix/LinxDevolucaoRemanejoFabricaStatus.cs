
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatus
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica_status { get; private set; }
        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDevolucaoRemanejoFabricaStatus() { }

        public LinxDevolucaoRemanejoFabricaStatus(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxDevolucaoRemanejoFabricaStatus record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_devolucao_remanejo_fabrica_status = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica_status);
            this.id_devolucao_remanejo_fabrica_tipo = CustomConvertersExtensions.ConvertToInt32Validation(record.id_devolucao_remanejo_fabrica_tipo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
