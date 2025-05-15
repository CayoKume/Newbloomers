using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxLinhas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_linha { get; private set; }

        [LengthValidation(length: 30, propertyName: "desc_linha")]
        public string? desc_linha { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_integracao_ws")]
        public string? codigo_integracao_ws { get; private set; }

        public Int32? portal { get; private set; }

        public decimal? coeficiente_comissao { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxLinhas() { }

        public LinxLinhas(
            List<ValidationResult> listValidations,
            string? id_linha,
            string? desc_linha,
            string? timestamp,
            string? codigo_integracao_ws,
            string? portal,
            string? coeficiente_comissao
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_linha =
                ConvertToInt32Validation.IsValid(id_linha, "id_linha", listValidations) ?
                Convert.ToInt32(id_linha) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.coeficiente_comissao =
                ConvertToDecimalValidation.IsValid(coeficiente_comissao, "coeficiente_comissao", listValidations) ?
                Convert.ToDecimal(coeficiente_comissao, new CultureInfo("en-US")) :
                0;

            this.desc_linha = desc_linha;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
