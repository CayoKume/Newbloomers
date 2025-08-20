
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCstPisFiscal
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? id_cst_pis_fiscal { get; private set; }
        public string? cst_pis_fiscal { get; private set; }
        public string? descricao { get; private set; }
        public bool? excluido { get; private set; }
        public DateTime? inicio_vigencia { get; private set; }
        public DateTime? termino_vigencia { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCstPisFiscal() { }

        public LinxCstPisFiscal(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCstPisFiscal record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_cst_pis_fiscal = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cst_pis_fiscal);
            this.excluido = CustomConvertersExtensions.ConvertToBooleanValidation(record.excluido);
            this.inicio_vigencia =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.inicio_vigencia);
            this.termino_vigencia =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.termino_vigencia);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cst_pis_fiscal = record.cst_pis_fiscal;
            this.descricao = record.descricao;
        }
    }
}
