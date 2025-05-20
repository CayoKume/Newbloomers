using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCstCofinsFiscal
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_csosn_fiscal { get; private set; }

        [LengthValidation(length: 5, propertyName: "csosn_fiscal")]
        public string? csosn_fiscal { get; private set; }

        [LengthValidation(length: 200, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int32? id_csosn_fiscal_substitutiva { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCstCofinsFiscal() { }

        public LinxCstCofinsFiscal(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_csosn_fiscal,
            string? csosn_fiscal,
            string? descricao,
            string? id_csosn_fiscal_substitutiva,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_csosn_fiscal =
                ConvertToInt32Validation.IsValid(id_csosn_fiscal, "id_csosn_fiscal", listValidations) ?
                Convert.ToInt32(id_csosn_fiscal) :
                0;

            this.id_csosn_fiscal_substitutiva =
                ConvertToInt32Validation.IsValid(id_csosn_fiscal_substitutiva, "id_csosn_fiscal_substitutiva", listValidations) ?
                Convert.ToInt32(id_csosn_fiscal_substitutiva) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.csosn_fiscal = csosn_fiscal;
            this.descricao = descricao;
        }
    }
}
