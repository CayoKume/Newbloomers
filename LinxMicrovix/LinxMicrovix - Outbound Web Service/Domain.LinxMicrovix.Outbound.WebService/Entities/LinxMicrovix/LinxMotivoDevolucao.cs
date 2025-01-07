using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMotivoDevolucao
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_motivo { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "descricao_motivo")]
        public string? descricao_motivo { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_deposito { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxMotivoDevolucao() { }

        public LinxMotivoDevolucao(
            List<ValidationResult> listValidations,
            string? cod_motivo,
            string? portal,
            string? descricao_motivo,
            string? cod_deposito,
            string? ativo,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_motivo =
                ConvertToInt32Validation.IsValid(cod_motivo, "cod_motivo", listValidations) ?
                Convert.ToInt32(cod_motivo) :
                0;

            this.cod_deposito =
                ConvertToInt32Validation.IsValid(cod_deposito, "cod_deposito", listValidations) ?
                Convert.ToInt32(cod_deposito) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.descricao_motivo = descricao_motivo;
        }
    }
}
