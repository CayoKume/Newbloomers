
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosCodBar
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; set; }
        public Int64? cod_produto { get; set; }
        public string? cod_barra { get; set; }
        public Int64? timestamp { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosCodBar() { }

        public LinxProdutosCodBar(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosCodBar record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_barra = record.cod_barra;
            this.recordKey = $"[{record.cod_produto}]|[{record.cod_barra}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
