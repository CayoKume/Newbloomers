using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxProdutosCodBar", Schema = "untreated")]
    public class LinxProdutosCodBar
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_produto { get; set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cod_barra")]
        public string? cod_barra { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        public LinxProdutosCodBar() { }

        public LinxProdutosCodBar(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_produto,
            string? cod_barra,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_barra = cod_barra;
        }
    }
}
