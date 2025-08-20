
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxECFFormasPagamento
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_empresa_ecf_formas_pgto { get; private set; }
        public Int32? id_ecf { get; private set; }
        public Int32? cod_forma_pgto { get; private set; }
        public string? indice_forma { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxECFFormasPagamento() { }

        public LinxECFFormasPagamento(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxECFFormasPagamento record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_empresa_ecf_formas_pgto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_empresa_ecf_formas_pgto);
            this.id_ecf = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ecf);
            this.cod_forma_pgto = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_forma_pgto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.indice_forma = record.indice_forma;
        }
    }
}
