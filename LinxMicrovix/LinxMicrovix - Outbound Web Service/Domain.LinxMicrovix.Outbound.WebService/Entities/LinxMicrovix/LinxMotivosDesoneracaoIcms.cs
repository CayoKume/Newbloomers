using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcms
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_motivos_desoneracao_icms { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 200, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMotivosDesoneracaoIcms() { }

        public LinxMotivosDesoneracaoIcms(
            List<ValidationResult> listValidations,
            string? id_motivos_desoneracao_icms,
            string? portal,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_motivos_desoneracao_icms =
                ConvertToInt32Validation.IsValid(id_motivos_desoneracao_icms, "id_motivos_desoneracao_icms", listValidations) ?
                Convert.ToInt32(id_motivos_desoneracao_icms) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
