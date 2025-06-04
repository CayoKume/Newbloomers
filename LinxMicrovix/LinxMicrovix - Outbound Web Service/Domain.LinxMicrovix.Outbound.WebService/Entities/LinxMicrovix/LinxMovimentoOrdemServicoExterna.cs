using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExterna
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_movimento_ordem_servico_externa { get; private set; }

        public Guid? identificador { get; private set; }

        [LengthValidation(length: 20, propertyName: "codigo_ordem_servico")]
        public string? codigo_ordem_servico { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoOrdemServicoExterna() { }

        public LinxMovimentoOrdemServicoExterna(
            List<ValidationResult> listValidations,
            string? id_movimento_ordem_servico_externa,
            string? identificador,
            string? codigo_ordem_servico,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_movimento_ordem_servico_externa =
                ConvertToInt32Validation.IsValid(id_movimento_ordem_servico_externa, "id_movimento_ordem_servico_externa", listValidations) ?
                Convert.ToInt32(id_movimento_ordem_servico_externa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.codigo_ordem_servico = codigo_ordem_servico;
        }
    }
}
