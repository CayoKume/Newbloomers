
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_campo { get; private set; }
        public Int32? ordem { get; private set; }
        public string? legenda { get; private set; }
        public string? tipo { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisNomes() { }

        public B2CConsultaProdutosCamposAdicionaisNomes(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCamposAdicionaisNomes record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_campo = CustomConvertersExtensions.ConvertToInt32Validation(record.id_campo);
            this.ordem = CustomConvertersExtensions.ConvertToInt32Validation(record.ordem);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.legenda = record.legenda;
            this.tipo = record.tipo;
            this.recordXml = recordXml;
        }
    }
}
