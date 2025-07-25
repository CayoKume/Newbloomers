using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosOpticosFormatoAro
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_formato_aro { get; private set; }

        [LengthValidation(length: 16, propertyName: "codigo")]
        public string? codigo { get; private set; }

        [LengthValidation(length: 60, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosOpticosFormatoAro() { }

        public LinxProdutosOpticosFormatoAro(
            List<ValidationResult> listValidations,
            string? id_formato_aro,
            string? codigo,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_formato_aro =
                ConvertToInt32Validation.IsValid(id_formato_aro, "id_formato_aro", listValidations) ?
                Convert.ToInt32(id_formato_aro) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo = codigo;
            this.descricao = descricao;
        }
    }
}
