using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaPlanosParcelas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPlanosParcelas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? plano { get; private set; }

        public Int32? ordem_parcela { get; private set; }

        public Int32? prazo_parc { get; private set; }

        public Int32? id_planos_parcelas { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaPlanosParcelas() { }

        public B2CConsultaPlanosParcelas(
            List<ValidationResult> listValidations,
            string? plano,
            string? ordem_parcela,
            string? prazo_parc,
            string? id_planos_parcelas,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.ordem_parcela =
                ConvertToInt32Validation.IsValid(ordem_parcela, "ordem_parcela", listValidations) ?
                Convert.ToInt32(ordem_parcela) :
                0;

            this.prazo_parc =
                ConvertToInt32Validation.IsValid(prazo_parc, "prazo_parc", listValidations) ?
                Convert.ToInt32(prazo_parc) :
                0;

            this.id_planos_parcelas =
                ConvertToInt32Validation.IsValid(id_planos_parcelas, "id_planos_parcelas", listValidations) ?
                Convert.ToInt32(id_planos_parcelas) :
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
