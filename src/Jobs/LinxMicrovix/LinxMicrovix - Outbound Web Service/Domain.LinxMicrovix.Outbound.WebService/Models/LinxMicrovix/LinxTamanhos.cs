
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxTamanhos
    {
		public DateTime? lastupdateon { get; private set; }
        public Int32? id { get; private set; }
        public string? id_tamanho { get; private set; }
        public string? desc_tamanho { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public bool? ativo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxTamanhos() { }

        public LinxTamanhos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxTamanhos record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.id_tamanho = record.id_tamanho;
            this.desc_tamanho = record.desc_tamanho;
            this.codigo_integracao_ws = record.codigo_integracao_ws;
        }
    }
}
