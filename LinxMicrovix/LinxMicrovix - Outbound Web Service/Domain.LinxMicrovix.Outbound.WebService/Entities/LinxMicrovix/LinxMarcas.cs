using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxMarcas
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_marca { get; private set; }

        [LengthValidation(length: 30, propertyName: "desc_marca")]
        public string? desc_marca { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMarcas() { }

        public LinxMarcas(
            List<ValidationResult> listValidations,
            string? id_marca,
            string? desc_marca,
            string? timestamp,
            string? codigo_integracao_ws
        )
        {
            lastupdateon = DateTime.Now;

            this.id_marca =
                ConvertToInt32Validation.IsValid(id_marca, "id_marca", listValidations) ?
                Convert.ToInt32(id_marca) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.desc_marca = desc_marca;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
