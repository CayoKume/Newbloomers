
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClassificacoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32 id_classificacao { get; private set; }
        public string? desc_classificacao { get; private set; }
        public Int64 timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public bool ativo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClassificacoes() { }

        public LinxClassificacoes(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxClassificacoes record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_classificacao = CustomConvertersExtensions.ConvertToInt32Validation(record.id_classificacao);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigo_integracao_ws = record.codigo_integracao_ws;
            this.desc_classificacao = record.desc_classificacao;
        }
    }
}
