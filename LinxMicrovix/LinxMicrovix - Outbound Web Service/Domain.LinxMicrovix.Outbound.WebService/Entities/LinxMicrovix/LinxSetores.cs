using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSetores
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_setor { get; private set; }

        [LengthValidation(length: 30, propertyName: "desc_setor")]
        public string? desc_setor { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        public Int32? ativo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSetores() { }

        public LinxSetores(
            List<ValidationResult> listValidations,
            string? id_setor,
            string? desc_setor,
            string? timestamp,
            string? codigo_integracao_ws,
            string? ativo,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_setor =
                ConvertToInt32Validation.IsValid(id_setor, "id_setor", listValidations) ?
                Convert.ToInt32(id_setor) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.desc_setor = desc_setor;
            this.recordKey = $"[{id_setor}]|[{timestamp}]";
            this.recordXml = recordXml;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
