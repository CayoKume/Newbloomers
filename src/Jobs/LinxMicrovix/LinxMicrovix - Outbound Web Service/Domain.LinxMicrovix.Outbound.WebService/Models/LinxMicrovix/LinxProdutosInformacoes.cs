
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosInformacoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; set; }
        public string? informacoes_produto { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosInformacoes() { }

        public LinxProdutosInformacoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosInformacoes record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.informacoes_produto = record.informacoes_produto;
        }
    }
}
