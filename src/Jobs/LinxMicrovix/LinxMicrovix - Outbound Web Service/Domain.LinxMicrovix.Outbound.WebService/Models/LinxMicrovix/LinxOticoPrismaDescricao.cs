
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOticoPrismaDescricao
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_otico_prisma_descricao { get; private set; }
        public string? descricao { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOticoPrismaDescricao() { }

        public LinxOticoPrismaDescricao(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOticoPrismaDescricao record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_otico_prisma_descricao = CustomConvertersExtensions.ConvertToInt32Validation(record.id_otico_prisma_descricao);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
