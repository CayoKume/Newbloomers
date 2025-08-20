
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosCamposAdicionais
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? cod_produto { get; private set; }
        public string? campo { get; private set; }
        public string? valor { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosCamposAdicionais() { }

        public LinxProdutosCamposAdicionais(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosCamposAdicionais record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.valor = record.valor;
            this.campo = record.campo;
            this.recordKey = $"[{record.cod_produto}]|[{record.campo}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
