using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaPedidosTipos", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPedidosTipos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tipo_b2c { get; private set; }

        [Column(TypeName = "varchar(200)")]
        [LengthValidation(length: 200, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? pos_timestamp_old { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPedidosTipos() { }

        public B2CConsultaPedidosTipos(
            List<ValidationResult> listValidations,
            string? id_tipo_b2c,
            string? descricao,
            string? pos_timestamp_old,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tipo_b2c =
                ConvertToInt32Validation.IsValid(id_tipo_b2c, "id_tipo_b2c", listValidations) ?
                Convert.ToInt32(id_tipo_b2c) :
                0;

            this.pos_timestamp_old =
                ConvertToInt64Validation.IsValid(pos_timestamp_old, "pos_timestamp_old", listValidations) ?
                Convert.ToInt64(pos_timestamp_old) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.descricao = descricao;
        }
    }
}
