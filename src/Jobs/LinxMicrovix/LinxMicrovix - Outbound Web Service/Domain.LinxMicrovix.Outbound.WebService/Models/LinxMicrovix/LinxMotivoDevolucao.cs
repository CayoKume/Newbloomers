
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMotivoDevolucao
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? cod_motivo { get; private set; }
        public Int32? portal { get; private set; }
        public string? descricao_motivo { get; private set; }
        public Int32? cod_deposito { get; private set; }
        public bool? ativo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMotivoDevolucao() { }

        public LinxMotivoDevolucao(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMotivoDevolucao record, string recordXml) 
        {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.cod_motivo = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_motivo);
            this.cod_deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_deposito);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.descricao_motivo = record.descricao_motivo;
        }
    }
}
