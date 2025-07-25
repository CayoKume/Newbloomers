using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxPerguntaVenda
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_pergunta_venda { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 200, propertyName: "descricao_pergunta")]
        public string? descricao_pergunta { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxPerguntaVenda() { }

        public LinxPerguntaVenda(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_pergunta_venda,
            string? descricao_pergunta,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_pergunta_venda =
                ConvertToInt32Validation.IsValid(id_pergunta_venda, "id_pergunta_venda", listValidations) ?
                Convert.ToInt32(id_pergunta_venda) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao_pergunta = descricao_pergunta;
        }
    }
}
