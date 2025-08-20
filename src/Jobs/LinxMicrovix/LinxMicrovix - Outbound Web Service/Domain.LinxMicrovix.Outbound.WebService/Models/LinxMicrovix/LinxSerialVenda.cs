
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxSerialVenda
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_serial_venda { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? transacao { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public string? serial { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSerialVenda() { }

        public LinxSerialVenda(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSerialVenda record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.id_serial_venda = CustomConvertersExtensions.ConvertToInt32Validation(record.id_serial_venda);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.serial = record.serial;
        }
    }
}
