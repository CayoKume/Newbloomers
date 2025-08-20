
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPedidosTipos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_tipo_b2c { get; private set; }
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
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPedidosTipos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_tipo_b2c = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tipo_b2c);
            this.pos_timestamp_old = CustomConvertersExtensions.ConvertToInt64Validation(record.pos_timestamp_old);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);

            this.descricao = record.descricao;
            this.recordXml = recordXml;
        }
    }
}
