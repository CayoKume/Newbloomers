using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaTags
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido_item { get; set; }

        [Column(TypeName = "varchar(300)")]
        [LengthValidation(length: 300, propertyName: "descricao")]
        public string? descricao { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        public B2CConsultaTags() { }

        public B2CConsultaTags(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_pedido_item,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido_item =
                ConvertToInt32Validation.IsValid(id_pedido_item, "id_pedido_item", listValidations) ?
                Convert.ToInt32(id_pedido_item) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
