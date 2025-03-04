using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxUnidades", Schema = "linx_microvix_erp")]
    public class LinxUnidades
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? idUnidade { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "unidade")]
        public string? unidade { get; private set; }

        [Column(TypeName = "varchar(200)")]
        [LengthValidation(length: 200, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxUnidades() { }

        public LinxUnidades(
            List<ValidationResult> listValidations,
            string? unidade,
            string? descricao,
            string? timestamp
        )
        {
            this.lastupdateon = DateTime.Now;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.unidade = unidade;
            this.descricao = descricao;
        }
    }
}
