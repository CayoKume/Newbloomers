
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOrdensServicoProdutos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_ordservprod { get; private set; }
        public Int64? cod_produto_serv { get; private set; }
        public Int32? numero_os { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdensServicoProdutos() { }

        public LinxOrdensServicoProdutos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOrdensServicoProdutos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_ordservprod = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ordservprod);
            this.cod_produto_serv = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto_serv);
            this.numero_os = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_os);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
        }
    }
}
