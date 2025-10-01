
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCodebar
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public string? codebar { get; private set; }
        public Int32? id_produtos_codebar { get; private set; }
        public Int32? principal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? tipo_codebar { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCodebar() { }

        public B2CConsultaProdutosCodebar(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCodebar record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.id_produtos_codebar = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_codebar);
            this.principal = CustomConvertersExtensions.ConvertToInt32Validation(record.principal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.tipo_codebar = record.tipo_codebar;
            this.codebar = record.codebar;
            this.recordXml = recordXml;
        }
    }
}
