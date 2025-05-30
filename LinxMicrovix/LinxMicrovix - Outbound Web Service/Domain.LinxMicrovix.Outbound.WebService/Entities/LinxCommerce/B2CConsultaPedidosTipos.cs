using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce
{
    public class B2CConsultaPedidosTipos
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_tipo_b2c { get; private set; }

        [LengthValidation(length: 200, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? pos_timestamp_old { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPedidosTipos() { }

        public B2CConsultaPedidosTipos(
            List<ValidationResult> listValidations,
            string? id_tipo_b2c,
            string? descricao,
            string? pos_timestamp_old,
            string? portal,
            string? recordXml
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
            this.recordXml = recordXml;
        }
    }
}
