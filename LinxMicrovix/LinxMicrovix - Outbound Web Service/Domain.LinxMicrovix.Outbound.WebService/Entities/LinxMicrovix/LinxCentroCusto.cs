using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxCentroCusto", Schema = "linx_microvix_erp")]
    public class LinxCentroCusto
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        [LengthValidation(length: 14, propertyName: "CNPJ")]
        public string? CNPJ { get; private set; }

        public Int32? id_centrocusto { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_centrocusto")]
        public string? nome_centrocusto { get; private set; }

        public bool? ativo { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCentroCusto() { }

        public LinxCentroCusto(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? CNPJ,
            string? id_centrocusto,
            string? nome_centrocusto,
            string? ativo,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_centrocusto =
                ConvertToInt32Validation.IsValid(id_centrocusto, "id_centrocusto", listValidations) ?
                Convert.ToInt32(id_centrocusto) :
                0;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.CNPJ = CNPJ;
            this.nome_centrocusto = nome_centrocusto;
        }
    }
}
