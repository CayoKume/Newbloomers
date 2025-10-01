
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMotivoDesconto
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_motivo_desconto { get; private set; }
        public string? desc_motivo_desconto { get; private set; }
        public bool? ativo { get; private set; }
        public bool? excluido { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMotivoDesconto() { }

        public LinxMotivoDesconto(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMotivoDesconto record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_motivo_desconto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_motivo_desconto);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.desc_motivo_desconto = record.desc_motivo_desconto;
        }
    }
}
