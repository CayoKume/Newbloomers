
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosOpticosTipo
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_produtos_opticos_tipo { get; private set; }
        public string? tipo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosOpticosTipo() { }

        public LinxProdutosOpticosTipo(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosOpticosTipo record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_produtos_opticos_tipo = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_tipo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.tipo = record.tipo;
        }
    }
}
