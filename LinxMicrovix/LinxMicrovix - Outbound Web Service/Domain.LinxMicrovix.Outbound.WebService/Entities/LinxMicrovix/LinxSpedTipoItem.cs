using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxSpedTipoItem
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_sped_tipo_item { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 2, propertyName: "codigo")]
        public string? codigo { get; private set; }

        [LengthValidation(length: 60, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSpedTipoItem() { }

        public LinxSpedTipoItem(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_sped_tipo_item,
            string? codigo,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_sped_tipo_item =
                ConvertToInt32Validation.IsValid(id_sped_tipo_item, "id_sped_tipo_item", listValidations) ?
                Convert.ToInt32(id_sped_tipo_item) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo = codigo;
            this.descricao = descricao;
        }
    }
}
