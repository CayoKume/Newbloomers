
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxNfceEstacao
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_nfce_estacao { get; private set; }
        public Int32? empresa { get; private set; }
        public string? descricao { get; private set; }
        public string? numero_pdv_tef { get; private set; }
        public bool? ativo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxNfceEstacao() { }

        public LinxNfceEstacao(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNfceEstacao record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_nfce_estacao = CustomConvertersExtensions.ConvertToInt32Validation(record.id_nfce_estacao);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
            this.numero_pdv_tef = record.numero_pdv_tef;
        }
    }
}
