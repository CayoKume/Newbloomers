using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMovimentoVendaConjugada", Schema = "linx_microvix_erp")]
    public class LinxMovimentoVendaConjugada
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_produto { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_servico { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoVendaConjugada() { }

        public LinxMovimentoVendaConjugada(
            List<ValidationResult> listValidations,
            string? identificador_produto,
            string? identificador_servico,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.identificador_produto =
                String.IsNullOrEmpty(identificador_produto) ? null
                : Guid.Parse(identificador_produto);

            this.identificador_servico =
                String.IsNullOrEmpty(identificador_servico) ? null
                : Guid.Parse(identificador_servico);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
