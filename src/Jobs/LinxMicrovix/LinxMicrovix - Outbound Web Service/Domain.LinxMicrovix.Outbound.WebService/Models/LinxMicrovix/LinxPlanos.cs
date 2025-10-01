
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPlanos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? plano { get; private set; }
        public string? desc_plano { get; private set; }
        public Int32? qtde_parcelas { get; private set; }
        public Int32? prazo_entre_parcelas { get; private set; }
        public string? tipo_plano { get; private set; }
        public decimal? indice_plano { get; private set; }
        public Int32? cod_forma_pgto { get; private set; }
        public string? forma_pgto { get; private set; }
        public Int32? conta_central { get; private set; }
        public string? tipo_transacao { get; private set; }
        public decimal? taxa_financeira { get; private set; }
        public DateTime? dt_upd { get; private set; }
        public string? desativado { get; private set; }
        public string? usa_tef { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPlanos() { }

        public LinxPlanos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPlanos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.qtde_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_parcelas);
            this.prazo_entre_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.prazo_entre_parcelas);
            this.cod_forma_pgto = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_forma_pgto);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.dt_upd = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_upd);
            this.indice_plano = CustomConvertersExtensions.ConvertToDecimalValidation(record.indice_plano);
            this.taxa_financeira = CustomConvertersExtensions.ConvertToDecimalValidation(record.taxa_financeira);
            this.desc_plano = record.desc_plano;
            this.tipo_plano = record.tipo_plano;
            this.forma_pgto = record.forma_pgto;
            this.tipo_transacao = record.tipo_transacao;
            this.desativado = record.desativado;
            this.usa_tef = record.usa_tef;
            this.recordKey = $"[{record.plano}]|[{record.timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
