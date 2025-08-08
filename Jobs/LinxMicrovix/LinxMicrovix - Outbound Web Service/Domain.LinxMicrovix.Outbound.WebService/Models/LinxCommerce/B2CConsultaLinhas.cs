using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaLinhas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_linha { get; private set; }
        public string? nome_linha { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? setores { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaLinhas() { }

        public B2CConsultaLinhas(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaLinhas record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_linha = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_linha);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_linha = record.nome_linha;
            this.setores = record.setores;
            this.recordXml = recordXml;
        }
    }
}
