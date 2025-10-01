
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaMarcas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_marca { get; private set; }
        public string? nome_marca { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? linhas { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaMarcas() { }

        public B2CConsultaMarcas(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaMarcas record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.codigo_marca = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_marca);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_marca = record.nome_marca;
            this.linhas = record.linhas;
            this.recordXml = recordXml;
        }
    }
}
