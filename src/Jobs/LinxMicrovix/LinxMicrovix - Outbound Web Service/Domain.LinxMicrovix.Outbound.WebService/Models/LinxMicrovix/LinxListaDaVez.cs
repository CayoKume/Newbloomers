
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxListaDaVez
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? cod_vendedor { get; private set; }
        public DateTime? data { get; private set; }
        public string? motivo_nao_venda { get; private set; }
        public Int32? qtde_ocorrencias { get; private set; }
        public DateTime? data_hora_ini_atend { get; private set; }
        public DateTime? data_hora_fim_atend { get; private set; }
        public string? obs { get; private set; }
        public string? desc_produto_neg { get; private set; }
        public decimal? valor_produto_neg { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxListaDaVez() { }

        public LinxListaDaVez(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxListaDaVez record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.qtde_ocorrencias = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_ocorrencias);
            this.valor_produto_neg = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_produto_neg);
            this.data =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.data_hora_ini_atend =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_hora_ini_atend);
            this.data_hora_fim_atend =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_hora_fim_atend);
            this.obs = record.obs;
            this.cnpj_emp = record.cnpj_emp;
            this.motivo_nao_venda = record.motivo_nao_venda;
            this.desc_produto_neg = record.desc_produto_neg;
        }
    }
}
