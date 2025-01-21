using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxColecoes", Schema = "untreated")]
    public class LinxColecoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_colecao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_colecao")]
        public string? desc_colecao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        public LinxColecoes() { }

        public LinxColecoes(
            List<ValidationResult> listValidations,
            string? id_colecao,
            string? desc_colecao,
            string? timestamp,
            string? codigo_integracao_ws
        )
        {
            lastupdateon = DateTime.Now;

            this.id_colecao =
                ConvertToInt32Validation.IsValid(id_colecao, "id_colecao", listValidations) ?
                Convert.ToInt32(id_colecao) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.desc_colecao = desc_colecao;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
