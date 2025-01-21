using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxCategoriasFinanceiras", Schema = "linx_microvix_erp")]
    public class LinxCategoriasFinanceiras
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_categorias_financeiras { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? historico { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxCategoriasFinanceiras() { }

        public LinxCategoriasFinanceiras(
            List<ValidationResult> listValidations,
            string? id_categorias_financeiras,
            string? descricao,
            string? ativo,
            string? historico,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_categorias_financeiras =
                ConvertToInt32Validation.IsValid(id_categorias_financeiras, "id_categorias_financeiras", listValidations) ?
                Convert.ToInt32(id_categorias_financeiras) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.historico =
                ConvertToInt64Validation.IsValid(historico, "historico", listValidations) ?
                Convert.ToInt64(historico) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
