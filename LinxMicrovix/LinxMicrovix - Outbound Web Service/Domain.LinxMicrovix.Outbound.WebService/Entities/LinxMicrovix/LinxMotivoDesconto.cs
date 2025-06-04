using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxMotivoDesconto
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_motivo_desconto { get; private set; }

        [LengthValidation(length: 60, propertyName: "desc_motivo_desconto")]
        public string? desc_motivo_desconto { get; private set; }

        public bool? ativo { get; private set; }

        public bool? excluido { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMotivoDesconto() { }

        public LinxMotivoDesconto(
            List<ValidationResult> listValidations,
            string? id_motivo_desconto,
            string? desc_motivo_desconto,
            string? ativo,
            string? excluido,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_motivo_desconto =
                ConvertToInt32Validation.IsValid(id_motivo_desconto, "id_motivo_desconto", listValidations) ?
                Convert.ToInt32(id_motivo_desconto) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.excluido =
                ConvertToBooleanValidation.IsValid(excluido, "excluido", listValidations) ?
                Convert.ToBoolean(excluido) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.desc_motivo_desconto = desc_motivo_desconto;
        }
    }
}
