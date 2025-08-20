using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoObservacaoCF
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Guid? identificador { get; private set; }

        [LengthValidation(length: 14, propertyName: "documento_cliente")]
        public string? documento_cliente { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoObservacaoCF() { }

        public LinxMovimentoObservacaoCF(
            List<ValidationResult> listValidations,
            string? identificador,
            string? documento_cliente,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.documento_cliente = documento_cliente;
        }
    }
}
