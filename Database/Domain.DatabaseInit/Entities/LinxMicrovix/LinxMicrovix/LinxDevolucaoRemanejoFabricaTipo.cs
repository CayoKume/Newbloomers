using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxDevolucaoRemanejoFabricaTipo", Schema = "untreated")]
    public class LinxDevolucaoRemanejoFabricaTipo
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxDevolucaoRemanejoFabricaTipo() { }

        public LinxDevolucaoRemanejoFabricaTipo(
            List<ValidationResult> listValidations,
            string? id_devolucao_remanejo_fabrica_tipo,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_devolucao_remanejo_fabrica_tipo =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica_tipo, "id_devolucao_remanejo_fabrica_tipo", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica_tipo) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
