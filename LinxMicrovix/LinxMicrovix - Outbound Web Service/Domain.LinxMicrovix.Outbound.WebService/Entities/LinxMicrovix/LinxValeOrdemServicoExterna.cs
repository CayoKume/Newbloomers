using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxValeOrdemServicoExterna
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_vale_ordem_servico_externa { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [LengthValidation(length: 25, propertyName: "numero_controle")]
        public string? numero_controle { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxValeOrdemServicoExterna() { }

        public LinxValeOrdemServicoExterna(
            List<ValidationResult> listValidations,
            string? id_vale_ordem_servico_externa,
            string? portal,
            string? cnpj_emp,
            string? numero_controle,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_vale_ordem_servico_externa =
                ConvertToInt32Validation.IsValid(id_vale_ordem_servico_externa, "id_vale_ordem_servico_externa", listValidations) ?
                Convert.ToInt32(id_vale_ordem_servico_externa) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.numero_controle = numero_controle;
        }
    }
}
