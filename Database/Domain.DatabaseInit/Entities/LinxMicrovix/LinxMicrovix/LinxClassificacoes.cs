using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxClassificacoes", Schema = "untreated")]
    public class LinxClassificacoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32 id_classificacao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "desc_classificacao")]
        public string? desc_classificacao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64 timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "bit")]
        public bool ativo { get; private set; }

        public LinxClassificacoes() { }

        public LinxClassificacoes(
            List<ValidationResult> listValidations,
            string? id_classificacao,
            string? desc_classificacao,
            string? timestamp,
            string? codigo_integracao_ws,
            string? ativo
        )
        {
            lastupdateon = DateTime.Now;

            this.id_classificacao =
                ConvertToInt32Validation.IsValid(id_classificacao, "id_classificacao", listValidations) ?
                Convert.ToInt32(id_classificacao) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo_integracao_ws = codigo_integracao_ws;
            this.desc_classificacao = desc_classificacao;
        }
    }
}
