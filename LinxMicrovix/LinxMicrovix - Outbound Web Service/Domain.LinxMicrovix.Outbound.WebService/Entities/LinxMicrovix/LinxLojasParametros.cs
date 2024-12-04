using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLojasParametros
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? percentual_minimo_antecipacao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxLojasParametros() { }

        public LinxLojasParametros(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? percentual_minimo_antecipacao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.percentual_minimo_antecipacao =
                ConvertToDecimalValidation.IsValid(percentual_minimo_antecipacao, "percentual_minimo_antecipacao", listValidations) ?
                Convert.ToDecimal(percentual_minimo_antecipacao) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
