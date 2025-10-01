
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaTipoEncomenda
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_tipo_encomenda { get; private set; }
        public string? nm_tipo_encomenda { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaTipoEncomenda() { }

        public B2CConsultaTipoEncomenda(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaTipoEncomenda record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_tipo_encomenda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tipo_encomenda);   
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.nm_tipo_encomenda = record.nm_tipo_encomenda;
            this.recordXml = recordXml;
        }
    }
}
