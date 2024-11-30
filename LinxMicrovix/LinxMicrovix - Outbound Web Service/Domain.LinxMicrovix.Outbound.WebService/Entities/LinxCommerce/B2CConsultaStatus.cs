using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_status { get; set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "descricao_status")]
        public string? descricao_status { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        public B2CConsultaStatus() { }

        public B2CConsultaStatus(
            List<ValidationResult> listValidations,
            string? id_status,
            string? descricao_status,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.descricao_status =
                String.IsNullOrEmpty(descricao_status) ? ""
                : descricao_status.Substring(
                    0,
                    descricao_status.Length > 30 ? 30
                    : descricao_status.Length
                );

            this.id_status =
                String.IsNullOrEmpty(id_status) ? 0
                : Convert.ToInt32(id_status);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
