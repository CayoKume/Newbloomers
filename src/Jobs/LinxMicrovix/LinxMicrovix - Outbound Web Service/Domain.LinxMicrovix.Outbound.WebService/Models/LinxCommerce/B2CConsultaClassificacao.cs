using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaClassificacao
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? codigo_classificacao { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_classificacao")]
        public string? nome_classificacao { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClassificacao() { }

        public B2CConsultaClassificacao(
            List<ValidationResult> listValidations,
            string? codigo_classificacao,
            string? nome_classificacao,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_classificacao =
                ConvertToInt32Validation.IsValid(codigo_classificacao, "codigo_classificacao", listValidations) ?
                Convert.ToInt32(codigo_classificacao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_classificacao = nome_classificacao;
            this.recordXml = recordXml;
        }
    }
}
