using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxRotinaOrigem
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_rotina { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }
        
        [Column(TypeName = "varchar(150)")]
        [LengthValidation(length: 150, propertyName: "descricao_rotina")]
        public string? descricao_rotina { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxRotinaOrigem() { }

        public LinxRotinaOrigem(
            List<ValidationResult> listValidations,
            string? portal,
            string? codigo_rotina,
            string? descricao_rotina,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.codigo_rotina =
                ConvertToInt32Validation.IsValid(codigo_rotina, "codigo_rotina", listValidations) ?
                Convert.ToInt32(codigo_rotina) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao_rotina = descricao_rotina;
        }
    }
}
