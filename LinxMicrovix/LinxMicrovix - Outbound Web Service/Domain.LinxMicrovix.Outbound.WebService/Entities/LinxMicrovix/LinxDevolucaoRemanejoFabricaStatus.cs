using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_devolucao_remanejo_fabrica_status { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }
        
        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "descricao")]
        public string? descricao { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxDevolucaoRemanejoFabricaStatus() { }

        public LinxDevolucaoRemanejoFabricaStatus(
            List<ValidationResult> listValidations,
            string? id_devolucao_remanejo_fabrica_status,
            string? id_devolucao_remanejo_fabrica_tipo,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_devolucao_remanejo_fabrica_status =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica_status, "id_devolucao_remanejo_fabrica_status", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica_status) :
                0;

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
