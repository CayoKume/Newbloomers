
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaPlanosParcelas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? plano { get; private set; }
        public Int32? ordem_parcela { get; private set; }
        public Int32? prazo_parc { get; private set; }
        public Int32? id_planos_parcelas { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPlanosParcelas() { }

        public B2CConsultaPlanosParcelas(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaPlanosParcelas record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.ordem_parcela = CustomConvertersExtensions.ConvertToInt32Validation(record.ordem_parcela);
            this.prazo_parc = CustomConvertersExtensions.ConvertToInt32Validation(record.prazo_parc);
            this.id_planos_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.id_planos_parcelas);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.recordXml = recordXml;
        }
    }
}
