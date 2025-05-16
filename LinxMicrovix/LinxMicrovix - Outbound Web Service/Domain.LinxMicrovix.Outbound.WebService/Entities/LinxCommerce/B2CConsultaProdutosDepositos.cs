using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDepositos
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_deposito { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_deposito")]
        public string? nome_deposito { get; private set; }

        [LengthValidation(length: 1, propertyName: "disponivel")]
        public string? disponivel { get; private set; }

        public Int32? disponivel_transferencia { get; private set; }

        public Int32? disponivel_franquias { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosDepositos() { }

        public B2CConsultaProdutosDepositos(
            List<ValidationResult> listValidations,
            string? id_deposito,
            string? nome_deposito,
            string? disponivel,
            string? disponivel_transferencia,
            string? disponivel_franquias,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_deposito =
                ConvertToInt32Validation.IsValid(id_deposito, "id_deposito", listValidations) ?
                Convert.ToInt32(id_deposito) :
                0;

            this.disponivel_transferencia =
                ConvertToInt32Validation.IsValid(disponivel_transferencia, "disponivel_transferencia", listValidations) ?
                Convert.ToInt32(disponivel_transferencia) :
                0;

            this.disponivel_franquias =
                ConvertToInt32Validation.IsValid(disponivel_franquias, "disponivel_franquias", listValidations) ?
                Convert.ToInt32(disponivel_franquias) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_deposito = nome_deposito;
            this.disponivel = disponivel;
            this.recordXml = recordXml;
        }
    }
}
