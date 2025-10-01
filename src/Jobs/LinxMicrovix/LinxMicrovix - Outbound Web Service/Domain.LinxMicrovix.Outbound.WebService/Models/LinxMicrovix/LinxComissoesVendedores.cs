
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxComissoesVendedores
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? vendedor { get; private set; }
        public Int32? empresa { get; private set; }
        public DateTime? data_origem { get; private set; }
        public decimal? valor_base { get; private set; }
        public decimal? valor_comissao { get; private set; }
        public string? cancelado { get; private set; }
        public string? disponivel { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxComissoesVendedores() { }

        public LinxComissoesVendedores(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxComissoesVendedores record, string recordXml) {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.vendedor);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.valor_base = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_base);
            this.valor_comissao = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_comissao);
            this.data_origem =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_origem);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cancelado = record.cancelado;
            this.disponivel = record.disponivel;
        }
    }
}
