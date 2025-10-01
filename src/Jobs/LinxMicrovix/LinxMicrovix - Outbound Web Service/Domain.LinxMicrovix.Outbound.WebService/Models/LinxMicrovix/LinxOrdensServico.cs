
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOrdensServico
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? numero_os { get; private set; }
        public Int32? empresa { get; private set; }
        public DateTime? data_os { get; private set; }
        public DateTime? data_envio_laboratorio { get; private set; }
        public string? cancelado { get; private set; }
        public Int32? id_laboratorio { get; private set; }
        public Int32? id_posicao_os_ramo_optico { get; private set; }
        public bool? compartilhar_hub_laboratorios { get; private set; }
        public Int32? cod_cliente_os { get; private set; }
        public Int32? cod_vendedor { get; private set; }
        public Int32? numero_sequencial_antecipacao_financeira { get; private set; }
        public string? chave_nfe_laboratorio { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdensServico() { }

        public LinxOrdensServico(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOrdensServico record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.numero_os = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_os);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_laboratorio = CustomConvertersExtensions.ConvertToInt32Validation(record.id_laboratorio);
            this.id_posicao_os_ramo_optico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_posicao_os_ramo_optico);
            this.cod_cliente_os = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente_os);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.numero_sequencial_antecipacao_financeira = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_sequencial_antecipacao_financeira);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.compartilhar_hub_laboratorios = CustomConvertersExtensions.ConvertToBooleanValidation(record.compartilhar_hub_laboratorios);
            this.data_os =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_os);
            this.data_envio_laboratorio =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_envio_laboratorio);
            this.cancelado = record.cancelado;
            this.chave_nfe_laboratorio = record.chave_nfe_laboratorio;
        }
    }
}
