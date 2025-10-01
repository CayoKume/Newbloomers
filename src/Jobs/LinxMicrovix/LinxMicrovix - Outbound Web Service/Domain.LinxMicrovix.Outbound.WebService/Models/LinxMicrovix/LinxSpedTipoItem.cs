
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxSpedTipoItem
    {
		public DateTime? lastupdateon { get; private set; }
        public Int32? id_sped_tipo_item { get; private set; }
        public Int32? portal { get; private set; }
        public string? codigo { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSpedTipoItem() { }

        public LinxSpedTipoItem(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSpedTipoItem record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_sped_tipo_item = CustomConvertersExtensions.ConvertToInt32Validation(record.id_sped_tipo_item);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo = record.codigo;
            this.descricao = record.descricao;
        }
    }
}
