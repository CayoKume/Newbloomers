using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaCodigoRastreio
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_pedido { get; private set; }

        public Int32? documento { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        [LengthValidation(length: 20, propertyName: "codigo_rastreio")]
        public string? codigo_rastreio { get; private set; }

        [LengthValidation(length: 20, propertyName: "sequencia_volume")]
        public string? sequencia_volume { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaCodigoRastreio() { }

        public B2CConsultaCodigoRastreio(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaCodigoRastreio record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_pedido = CustomConvertersExtensions.ConvertToInt32Validation(record.id_pedido);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.serie = record.serie;
            this.codigo_rastreio = record.codigo_rastreio;
            this.sequencia_volume = record.sequencia_volume;
            this.recordXml = recordXml;
        }
    }
}
