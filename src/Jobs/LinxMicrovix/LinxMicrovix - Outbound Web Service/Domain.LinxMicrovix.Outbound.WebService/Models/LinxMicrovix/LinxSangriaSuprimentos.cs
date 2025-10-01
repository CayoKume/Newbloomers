
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxSangriaSuprimentos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? usuario { get; private set; }
        public DateTime? data { get; private set; }
        public decimal? valor { get; private set; }
        public string? obs { get; private set; }
        public string? cancelado { get; private set; }
        public bool? conferido { get; private set; }
        public Int64? cod_historico { get; private set; }
        public string? desc_historico { get; private set; }
        public Int32? id_sangria_suprimentos { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSangriaSuprimentos() { }

        public LinxSangriaSuprimentos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSangriaSuprimentos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.usuario = CustomConvertersExtensions.ConvertToInt32Validation(record.usuario);
            this.id_sangria_suprimentos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_sangria_suprimentos);
            this.cod_historico = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_historico);
            this.data =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.conferido = CustomConvertersExtensions.ConvertToBooleanValidation(record.conferido);
            this.cnpj_emp = record.cnpj_emp;
            this.cancelado = record.cancelado;
            this.desc_historico = record.desc_historico;
            this.obs = record.obs;
        }
    }
}
