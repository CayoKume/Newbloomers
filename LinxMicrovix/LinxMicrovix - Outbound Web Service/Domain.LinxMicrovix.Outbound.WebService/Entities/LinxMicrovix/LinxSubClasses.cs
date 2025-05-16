using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSubClasses
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_subclasses { get; private set; }

        public Int32? classe { get; private set; }

        [LengthValidation(length: 50, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSubClasses() { }

        public LinxSubClasses(
            List<ValidationResult> listValidations,
            string? id_subclasses,
            string? classe,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_subclasses =
                ConvertToInt32Validation.IsValid(id_subclasses, "id_subclasses", listValidations) ?
                Convert.ToInt32(id_subclasses) :
                0;

            this.classe =
                ConvertToInt32Validation.IsValid(classe, "classe", listValidations) ?
                Convert.ToInt32(classe) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
