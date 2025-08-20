
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosOpticosFormatoAro
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_formato_aro { get; private set; }
        public string? codigo { get; private set; }
        public string? descricao { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosOpticosFormatoAro() { }

        public LinxProdutosOpticosFormatoAro(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosOpticosFormatoAro record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_formato_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_formato_aro);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo = record.codigo;
            this.descricao = record.descricao;
        }
    }
}
