
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosSerial
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public string? serial { get; private set; }
        public Int32? id_deposito { get; private set; }
        public bool? saldo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosSerial() { }

        public LinxProdutosSerial(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosSerial record, string recordXml) {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.id_deposito);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.saldo = CustomConvertersExtensions.ConvertToBooleanValidation(record.saldo);
            this.serial = record.serial;
        }
    }
}
