using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxMovimentoRemessas", Schema = "untreated")]
    public class LinxMovimentoRemessas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_remessas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_tipo { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_remessa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? status { get; private set; }

        [Column(TypeName = "varchar(35)")]
        [LengthValidation(length: 35, propertyName: "status_descricao")]
        public string? status_descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxMovimentoRemessas() { }

        public LinxMovimentoRemessas(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? id_remessas,
            string? id_tipo,
            string? identificador_remessa,
            string? status,
            string? status_descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_remessas =
                ConvertToInt32Validation.IsValid(id_remessas, "id_remessas", listValidations) ?
                Convert.ToInt32(id_remessas) :
                0;

            this.id_tipo =
                ConvertToInt32Validation.IsValid(id_tipo, "id_tipo", listValidations) ?
                Convert.ToInt32(id_tipo) :
                0;

            this.status =
                ConvertToInt32Validation.IsValid(status, "status", listValidations) ?
                Convert.ToInt32(status) :
                0;

            this.identificador_remessa =
                String.IsNullOrEmpty(identificador_remessa) ? null
                : Guid.Parse(identificador_remessa);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.status_descricao = status_descricao;
        }
    }
}
