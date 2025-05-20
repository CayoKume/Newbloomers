using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCodebar
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? codigoproduto { get; private set; }

        [LengthValidation(length: 20, propertyName: "codebar")]
        public string? codebar { get; private set; }

        public Int32? id_produtos_codebar { get; private set; }

        public Int32? principal { get; private set; }

        public Int32? empresa { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 20, propertyName: "tipo_codebar")]
        public string? tipo_codebar { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCodebar() { }

        public B2CConsultaProdutosCodebar(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? codebar,
            string? id_produtos_codebar,
            string? principal,
            string? empresa,
            string? timestamp,
            string? tipo_codebar,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.id_produtos_codebar =
                ConvertToInt32Validation.IsValid(id_produtos_codebar, "id_produtos_codebar", listValidations) ?
                Convert.ToInt32(id_produtos_codebar) :
                0;

            this.principal =
                ConvertToInt32Validation.IsValid(principal, "principal", listValidations) ?
                Convert.ToInt32(principal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.tipo_codebar = tipo_codebar;
            this.codebar = codebar;
            this.recordXml = recordXml;
        }
    }
}
