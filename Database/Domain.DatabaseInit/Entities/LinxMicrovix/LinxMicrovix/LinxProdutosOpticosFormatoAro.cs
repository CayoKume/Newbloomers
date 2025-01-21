using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxProdutosOpticosFormatoAro", Schema = "untreated")]
    public class LinxProdutosOpticosFormatoAro
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_formato_aro { get; private set; }

        [Column(TypeName = "varchar(16)")]
        [LengthValidation(length: 16, propertyName: "codigo")]
        public string? codigo { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

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
