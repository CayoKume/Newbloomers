
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaColecoes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_colecao { get; private set; }
        public string? nome_colecao { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? marcas { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaColecoes() { }

        public B2CConsultaColecoes(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaColecoes record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_colecao = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_colecao);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome_colecao = record.nome_colecao;
            this.marcas = record.marcas;
            this.recordXml = recordXml;
        }
    }
}
