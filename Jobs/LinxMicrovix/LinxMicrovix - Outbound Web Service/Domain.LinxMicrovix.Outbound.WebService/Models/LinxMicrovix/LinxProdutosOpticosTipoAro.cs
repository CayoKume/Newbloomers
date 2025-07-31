using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosOpticosTipoAro
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_tipo_aro { get; private set; }

        [LengthValidation(length: 100, propertyName: "tipo_aro")]
        public string? tipo_aro { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosOpticosTipoAro() { }

        public LinxProdutosOpticosTipoAro(
            List<ValidationResult> listValidations,
            string? id_tipo_aro,
            string? tipo_aro,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tipo_aro =
                ConvertToInt32Validation.IsValid(id_tipo_aro, "id_tipo_aro", listValidations) ?
                Convert.ToInt32(id_tipo_aro) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.tipo_aro = tipo_aro;
        }
    }
}
