using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxClientesFornecContatosParentesco
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32 id_parentesco { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao_parentesco")]
        public string? descricao_parentesco { get; private set; }

        public Int64 timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesFornecContatosParentesco() { }

        public LinxClientesFornecContatosParentesco(
            List<ValidationResult> listValidations,
            string? id_parentesco,
            string? descricao_parentesco,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_parentesco =
                ConvertToInt32Validation.IsValid(id_parentesco, "id_parentesco", listValidations) ?
                Convert.ToInt32(id_parentesco) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao_parentesco = descricao_parentesco;
        }
    }
}
