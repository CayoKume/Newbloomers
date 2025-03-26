using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaNFeSituacao", Schema = "linx_microvix_commerce")]
    public class B2CConsultaNFeSituacao
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_nfe_situacao { get; private set; }

        [LengthValidation(length: 30, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaNFeSituacao() { }

        public B2CConsultaNFeSituacao(
            List<ValidationResult> listValidations,
            string? id_nfe_situacao,
            string? descricao,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_nfe_situacao =
                ConvertToInt32Validation.IsValid(id_nfe_situacao, "id_nfe_situacao", listValidations) ?
                Convert.ToInt32(id_nfe_situacao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
            this.recordKey = $"[{id_nfe_situacao}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
