using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxRamosAtividade
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_ramo_atividade { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }
        
        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_ramo_atividade")]
        public string? nome_ramo_atividade { get; private set; }
        
        [Column(TypeName = "varchar(12)")]
        [LengthValidation(length: 12, propertyName: "codigo_ramo_atividade")]
        public string? codigo_ramo_atividade { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxRamosAtividade() { }

        public LinxRamosAtividade(
            List<ValidationResult> listValidations,
            string? id_ramo_atividade,
            string? portal,
            string? nome_ramo_atividade,
            string? codigo_ramo_atividade,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_ramo_atividade =
                ConvertToInt32Validation.IsValid(id_ramo_atividade, "id_ramo_atividade", listValidations) ?
                Convert.ToInt32(id_ramo_atividade) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_ramo_atividade = nome_ramo_atividade;
            this.codigo_ramo_atividade = codigo_ramo_atividade;
        }
    }
}
