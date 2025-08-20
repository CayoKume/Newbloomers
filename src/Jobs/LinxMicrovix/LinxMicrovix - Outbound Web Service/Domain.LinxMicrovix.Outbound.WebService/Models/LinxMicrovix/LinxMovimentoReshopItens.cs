
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoReshopItens
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_movimento_campanha_reshop_item { get; private set; }
        public Int32? id_campanha { get; private set; }
        public Guid? identificador { get; private set; }
        public decimal? valor_unitario { get; private set; }
        public decimal? valor_desconto_item { get; private set; }
        public decimal quantidade { get; private set; }
        public decimal? valor_original { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? ordem { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoReshopItens() { }

        public LinxMovimentoReshopItens(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMovimentoReshopItens record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_movimento_campanha_reshop_item = CustomConvertersExtensions.ConvertToInt32Validation(record.id_movimento_campanha_reshop_item);
            this.id_campanha = CustomConvertersExtensions.ConvertToInt32Validation(record.id_campanha);
            this.ordem = CustomConvertersExtensions.ConvertToInt32Validation(record.ordem);
            this.valor_unitario = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_unitario);
            this.valor_desconto_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_desconto_item);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.valor_original = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_original);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
        }
    }
}
