
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCstIcmsFiscal
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_cst_icms_fiscal { get; private set; }
        public string? cst_icms_fiscal { get; private set; }
        public string? descricao { get; private set; }
        public bool? substituicao_tributaria { get; private set; }
        public bool? excluido { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCstIcmsFiscal() { }

        public LinxCstIcmsFiscal(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCstIcmsFiscal record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_cst_icms_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_icms_fiscal);
            this.substituicao_tributaria = CustomConvertersExtensions.ConvertToBooleanValidation(record.substituicao_tributaria);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
            this.cst_icms_fiscal = record.cst_icms_fiscal;
        }
    }
}
