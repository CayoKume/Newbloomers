using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValores
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_campo_valor { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int32? id_campo_detalhe { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisValores() { }

        public B2CConsultaProdutosCamposAdicionaisValores(
            List<ValidationResult> listValidations,
            string? id_campo_valor,
            string? codigoproduto,
            string? id_campo_detalhe,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_campo_valor =
                ConvertToInt32Validation.IsValid(id_campo_valor, "id_campo_valor", listValidations) ?
                Convert.ToInt32(id_campo_valor) :
                0;

            this.id_campo_detalhe =
                ConvertToInt32Validation.IsValid(id_campo_detalhe, "id_campo_detalhe", listValidations) ?
                Convert.ToInt32(id_campo_detalhe) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.recordXml = recordXml;
        }
    }
}
