using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxFaturasOrigem", Schema = "linx_microvix_erp")]
    public class LinxFaturasOrigem
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigo_fatura { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigo_fatura_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFaturasOrigem() { }

        public LinxFaturasOrigem(
            List<ValidationResult> listValidations,
            string? codigo_fatura,
            string? codigo_fatura_origem,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_fatura =
                ConvertToInt64Validation.IsValid(codigo_fatura, "codigo_fatura", listValidations) ?
                Convert.ToInt64(codigo_fatura) :
                0;

            this.codigo_fatura_origem =
                ConvertToInt64Validation.IsValid(codigo_fatura_origem, "codigo_fatura_origem", listValidations) ?
                Convert.ToInt64(codigo_fatura_origem) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
