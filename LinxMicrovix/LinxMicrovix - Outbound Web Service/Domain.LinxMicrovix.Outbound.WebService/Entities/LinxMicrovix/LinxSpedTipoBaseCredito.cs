using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxSpedTipoBaseCredito", Schema = "linx_microvix_erp")]
    public class LinxSpedTipoBaseCredito
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_sped_tipo_base_credito { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 2, propertyName: "codigo_sped_tipo_base_credito")]
        public string? codigo_sped_tipo_base_credito { get; private set; }

        [LengthValidation(length: 150, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSpedTipoBaseCredito() { }

        public LinxSpedTipoBaseCredito(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_sped_tipo_base_credito,
            string? codigo_sped_tipo_base_credito,
            string? descricao,
            string? timestamp
        )
        {
            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_sped_tipo_base_credito =
                ConvertToInt32Validation.IsValid(id_sped_tipo_base_credito, "id_sped_tipo_base_credito", listValidations) ?
                Convert.ToInt32(id_sped_tipo_base_credito) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
            this.codigo_sped_tipo_base_credito = codigo_sped_tipo_base_credito;
        }
    }
}
