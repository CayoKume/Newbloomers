using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxCores", Schema = "linx_microvix_erp")]
    public class LinxCores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_cor { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "desc_cor")]
        public string? desc_cor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ativo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCores() { }

        public LinxCores(
            List<ValidationResult> listValidations,
            string? id_cor,
            string? desc_cor,
            string? timestamp,
            string? codigo_integracao_ws,
            string? ativo
        )
        {
            lastupdateon = DateTime.Now;

            this.id_cor =
                ConvertToInt32Validation.IsValid(id_cor, "id_cor", listValidations) ?
                Convert.ToInt32(id_cor) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.desc_cor = desc_cor;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
