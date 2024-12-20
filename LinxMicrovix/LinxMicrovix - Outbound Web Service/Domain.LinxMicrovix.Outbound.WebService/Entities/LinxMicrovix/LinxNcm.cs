using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxNcm
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "codigo")]
        public string? codigo { get; private set; }
        
        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "descricao")]
        public string? descricao { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? codigo_genero { get; private set; }
        
        [Column(TypeName = "bit")]
        public bool? ativo { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_ncm { get; private set; }
        
        [Column(TypeName = "int")]
        public Int64? timestamp { get; private set; }

        public LinxNcm() { }

        public LinxNcm(
            List<ValidationResult> listValidations,
            string? portal,
            string? codigo,
            string? descricao,
            string? codigo_genero,
            string? ativo,
            string? id_ncm,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.codigo_genero =
                ConvertToInt32Validation.IsValid(codigo_genero, "codigo_genero", listValidations) ?
                Convert.ToInt32(codigo_genero) :
                0;

            this.id_ncm =
                ConvertToInt32Validation.IsValid(id_ncm, "id_ncm", listValidations) ?
                Convert.ToInt32(id_ncm) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
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
