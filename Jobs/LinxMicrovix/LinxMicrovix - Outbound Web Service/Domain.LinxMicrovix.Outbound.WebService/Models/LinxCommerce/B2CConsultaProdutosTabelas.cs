using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosTabelas
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_tabela { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_tabela")]
        public string? nome_tabela { get; private set; }

        [LengthValidation(length: 1, propertyName: "ativa")]
        public string? ativa { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosTabelas() { }

        public B2CConsultaProdutosTabelas(
            List<ValidationResult> listValidations,
            string? id_tabela,
            string? nome_tabela,
            string? ativa,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tabela =
                ConvertToInt32Validation.IsValid(id_tabela, "id_tabela", listValidations) ?
                Convert.ToInt32(id_tabela) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_tabela = nome_tabela;
            this.ativa = ativa;
            this.recordXml = recordXml;
        }
    }
}
