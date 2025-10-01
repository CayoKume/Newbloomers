
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxLotesProdutos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_lote { get; private set; }
        public Int64? codigo_produto { get; private set; }
        public string? lote { get; private set; }
        public Guid? identificador { get; private set; }
        public Int32? transacao { get; private set; }
        public DateTime? data_fabricacao { get; private set; }
        public DateTime? data_vencimento { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxLotesProdutos() { }

        public LinxLotesProdutos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxLotesProdutos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.data_fabricacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_fabricacao);
            this.data_vencimento =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_vencimento);
            this.id_lote = CustomConvertersExtensions.ConvertToInt32Validation(record.id_lote);
            this.transacao = CustomConvertersExtensions.ConvertToInt32Validation(record.transacao);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.identificador = Guid.Parse(record.identificador);
            this.codigo_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_produto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.lote = record.lote;
        }
    }
}
