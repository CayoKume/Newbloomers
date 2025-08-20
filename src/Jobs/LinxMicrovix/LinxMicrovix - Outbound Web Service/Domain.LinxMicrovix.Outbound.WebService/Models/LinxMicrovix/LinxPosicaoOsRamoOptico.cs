using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPosicaoOsRamoOptico
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_posicao_os_ramo_optico { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao")]
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

        public LinxPosicaoOsRamoOptico(
            List<ValidationResult> listValidations,
            string? id_posicao_os_ramo_optico,
            string? descricao,
            string? codigo_status_padrao,
            string? ativo,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_posicao_os_ramo_optico =
                ConvertToInt32Validation.IsValid(id_posicao_os_ramo_optico, "id_posicao_os_ramo_optico", listValidations) ?
                Convert.ToInt32(id_posicao_os_ramo_optico) :
                0;

            this.codigo_status_padrao =
                ConvertToInt32Validation.IsValid(codigo_status_padrao, "codigo_status_padrao", listValidations) ?
                Convert.ToInt32(codigo_status_padrao) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
