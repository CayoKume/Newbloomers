
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistorico
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_ordens_servico_posicao_os_ramo_optico_historico { get; private set; }
        public Int32? numero_os { get; private set; }
        public Int32? usuario { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? id_posicao_os_ramo_optico { get; private set; }
        public DateTime? data { get; private set; }
        public string? observacao { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdensServicoPosicaoOsRamoOpticoHistorico() { }

        public LinxOrdensServicoPosicaoOsRamoOpticoHistorico(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOrdensServicoPosicaoOsRamoOpticoHistorico record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id_ordens_servico_posicao_os_ramo_optico_historico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ordens_servico_posicao_os_ramo_optico_historico);
            this.numero_os = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_os);
            this.usuario = CustomConvertersExtensions.ConvertToInt32Validation(record.usuario);
            this.id_posicao_os_ramo_optico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_posicao_os_ramo_optico);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.data =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.observacao = record.observacao;
        }
    }
}
