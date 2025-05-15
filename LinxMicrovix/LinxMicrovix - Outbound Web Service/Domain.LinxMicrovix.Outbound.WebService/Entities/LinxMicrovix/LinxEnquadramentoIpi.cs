using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxEnquadramentoIpi
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? id_enquadramento_ipi { get; private set; }

        [LengthValidation(length: 3, propertyName: "codigo")]
        public string? codigo { get; private set; }

        [LengthValidation(length: 600, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxEnquadramentoIpi() { }

        public LinxEnquadramentoIpi(
            List<ValidationResult> listValidations,
            string? portal,
            string? id_enquadramento_ipi,
            string? codigo,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_enquadramento_ipi =
                ConvertToInt32Validation.IsValid(id_enquadramento_ipi, "id_enquadramento_ipi", listValidations) ?
                Convert.ToInt32(id_enquadramento_ipi) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo = codigo;
            this.descricao = descricao;
        }
    }
}
