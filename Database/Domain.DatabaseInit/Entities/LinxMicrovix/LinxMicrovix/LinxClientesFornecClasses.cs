using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxClientesFornecClasses", Schema = "untreated")]
    public class LinxClientesFornecClasses
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32 portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32 cod_cliente { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32 cod_classe { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_classe")]
        public string? nome_classe { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64 timestamp { get; private set; }

        public LinxClientesFornecClasses() { }

        public LinxClientesFornecClasses(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_cliente,
            string? cod_classe,
            string? nome_classe,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.cod_classe =
                ConvertToInt32Validation.IsValid(cod_classe, "cod_classe", listValidations) ?
                Convert.ToInt32(cod_classe) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_classe = nome_classe;
        }
    }
}
