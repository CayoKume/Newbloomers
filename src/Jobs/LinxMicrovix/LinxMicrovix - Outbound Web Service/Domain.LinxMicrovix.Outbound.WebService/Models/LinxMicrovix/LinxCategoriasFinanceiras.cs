
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCategoriasFinanceiras
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_categorias_financeiras { get; private set; }
        public string? descricao { get; private set; }
        public bool? ativo { get; private set; }
        public Int64? historico { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCategoriasFinanceiras() { }

        public LinxCategoriasFinanceiras(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCategoriasFinanceiras record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_categorias_financeiras = CustomConvertersExtensions.ConvertToInt32Validation(record.id_categorias_financeiras);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.historico = CustomConvertersExtensions.ConvertToInt64Validation(record.historico);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
