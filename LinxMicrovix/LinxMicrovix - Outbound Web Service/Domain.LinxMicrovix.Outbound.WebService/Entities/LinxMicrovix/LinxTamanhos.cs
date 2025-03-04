using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxTamanhos", Schema = "linx_microvix_erp")]
    public class LinxTamanhos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id { get; private set; }

        [Column(TypeName = "varchar(5)")]
        [LengthValidation(length: 5, propertyName: "id_tamanho")]
        public string? id_tamanho { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_tamanho")]
        public string? desc_tamanho { get; private set; }

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

        public LinxTamanhos() { }

        public LinxTamanhos(
            List<ValidationResult> listValidations,
            string? id_tamanho,
            string? desc_tamanho,
            string? timestamp,
            string? codigo_integracao_ws,
            string? ativo
        )
        {
            lastupdateon = DateTime.Now;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.id_tamanho = id_tamanho;
            this.desc_tamanho = desc_tamanho;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
