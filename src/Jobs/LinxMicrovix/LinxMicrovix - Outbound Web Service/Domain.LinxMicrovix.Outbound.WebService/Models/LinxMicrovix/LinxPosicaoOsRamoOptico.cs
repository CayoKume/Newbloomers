
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPosicaoOsRamoOptico
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_posicao_os_ramo_optico { get; private set; }
        public string? descricao { get; private set; }
        public Int32? codigo_status_padrao { get; private set; }
        public bool? ativo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPosicaoOsRamoOptico() { }

        public LinxPosicaoOsRamoOptico(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxPosicaoOsRamoOptico record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_posicao_os_ramo_optico = CustomConvertersExtensions.ConvertToInt32Validation(record.id_posicao_os_ramo_optico);
            this.codigo_status_padrao = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_status_padrao);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.descricao = record.descricao;
        }
    }
}
