
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxSubClasses
    {
		public DateTime? lastupdateon { get; private set; }
        public Int32? id_subclasses { get; private set; }
        public Int32? classe { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSubClasses() { }

        public LinxSubClasses(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSubClasses record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_subclasses = CustomConvertersExtensions.ConvertToInt32Validation(record.id_subclasses);
            this.classe = CustomConvertersExtensions.ConvertToInt32Validation(record.classe);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
