using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMovimentoRemessas", Schema = "linx_microvix_erp")]
    public class LinxMovimentoRemessas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_remessas { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? id_tipo { get; private set; }

        public Guid? identificador_remessa { get; private set; }

        public Int32? status { get; private set; }

        [LengthValidation(length: 35, propertyName: "status_descricao")]
        public string? status_descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoRemessas() { }

        public LinxMovimentoRemessas(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? id_remessas,
            string? id_tipo,
            string? identificador_remessa,
            string? status,
            string? status_descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_remessas =
                ConvertToInt32Validation.IsValid(id_remessas, "id_remessas", listValidations) ?
                Convert.ToInt32(id_remessas) :
                0;

            this.id_tipo =
                ConvertToInt32Validation.IsValid(id_tipo, "id_tipo", listValidations) ?
                Convert.ToInt32(id_tipo) :
                0;

            this.status =
                ConvertToInt32Validation.IsValid(status, "status", listValidations) ?
                Convert.ToInt32(status) :
                0;

            this.identificador_remessa =
                String.IsNullOrEmpty(identificador_remessa) ? null
                : Guid.Parse(identificador_remessa);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.status_descricao = status_descricao;
        }
    }
}
