
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMetasVendedoresDia
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_meta { get; private set; }
        public string? descricao_meta { get; private set; }
        public DateTime? data_inicial_meta { get; private set; }
        public DateTime? data_final_meta { get; private set; }
        public DateTime? dia { get; private set; }
        public decimal? valor_meta_diaria { get; private set; }
        public Int32? cod_vendedor { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMetasVendedoresDia() { }

        public LinxMetasVendedoresDia(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxMetasVendedoresDia record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_meta = CustomConvertersExtensions.ConvertToInt32Validation(record.id_meta);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.valor_meta_diaria = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_meta_diaria);
            this.data_inicial_meta =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_inicial_meta);
            this.data_final_meta =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_final_meta);
            this.dia =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dia);
            this.cnpj_emp = record.cnpj_emp;
            this.descricao_meta = record.descricao_meta;
        }
    }
}
