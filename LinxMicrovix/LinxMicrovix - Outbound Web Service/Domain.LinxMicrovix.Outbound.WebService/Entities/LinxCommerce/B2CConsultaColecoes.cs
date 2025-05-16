using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaColecoes
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_colecao { get; private set; }

        [LengthValidation(length: 100, propertyName: "nome_colecao")]
        public string? nome_colecao { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 250, propertyName: "marcas")]
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
            List<ValidationResult> listValidations,
            string? codigo_colecao,
            string? nome_colecao,
            string? timestamp,
            string? marcas,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_colecao =
                ConvertToInt32Validation.IsValid(codigo_colecao, "codigo_colecao", listValidations) ?
                Convert.ToInt32(codigo_colecao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_colecao = nome_colecao;
            this.marcas = marcas;
            this.recordXml = recordXml;
        }
    }
}
