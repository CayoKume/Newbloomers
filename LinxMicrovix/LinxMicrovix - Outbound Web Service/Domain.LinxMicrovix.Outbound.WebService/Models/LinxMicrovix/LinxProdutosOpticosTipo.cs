using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosOpticosTipo
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_produtos_opticos_tipo { get; private set; }

        [LengthValidation(length: 100, propertyName: "tipo")]
        public string? tipo { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosOpticosTipo() { }

        public LinxProdutosOpticosTipo(
            List<ValidationResult> listValidations,
            string? id_produtos_opticos_tipo,
            string? tipo,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_produtos_opticos_tipo =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_tipo, "id_produtos_opticos_tipo", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_tipo) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.tipo = tipo;
        }
    }
}
