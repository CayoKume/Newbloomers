using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoObservacoes
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_obs { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 50, propertyName: "titulo_obs")]
        public string? titulo_obs { get; private set; }

        [LengthValidation(length: 250, propertyName: "descricao_obs")]
        public string? descricao_obs { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoObservacoes() { }

        public LinxMovimentoObservacoes(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_obs,
            string? titulo_obs,
            string? descricao_obs,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_obs =
                ConvertToInt32Validation.IsValid(id_obs, "id_obs", listValidations) ?
                Convert.ToInt32(id_obs) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.titulo_obs = titulo_obs;
            this.descricao_obs = descricao_obs;
        }
    }
}
