
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxSpedTipoBaseCredito
    {
		public DateTime? lastupdateon { get; private set; }
        public Int32? id_sped_tipo_base_credito { get; private set; }
        public Int32? portal { get; private set; }
        public string? codigo_sped_tipo_base_credito { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSpedTipoBaseCredito() { }

        public LinxSpedTipoBaseCredito(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSpedTipoBaseCredito record, string recordXml) {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_sped_tipo_base_credito = CustomConvertersExtensions.ConvertToInt32Validation(record.id_sped_tipo_base_credito);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
            this.codigo_sped_tipo_base_credito = record.codigo_sped_tipo_base_credito;
        }
    }
}
