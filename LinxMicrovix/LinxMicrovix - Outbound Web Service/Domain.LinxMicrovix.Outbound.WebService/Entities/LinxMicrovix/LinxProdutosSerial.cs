using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosSerial
    {
        public DateTime? lastupdateon { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        [LengthValidation(length: 50, propertyName: "serial")]
        public string? serial { get; private set; }

        public Int32? id_deposito { get; private set; }

        public bool? saldo { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosSerial() { }

        public LinxProdutosSerial(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? portal,
            string? empresa,
            string? serial,
            string? id_deposito,
            string? saldo,
            string? timestamp
        )
        {
            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_deposito =
                ConvertToInt32Validation.IsValid(id_deposito, "id_deposito", listValidations) ?
                Convert.ToInt32(id_deposito) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.saldo =
                ConvertToBooleanValidation.IsValid(saldo, "saldo", listValidations) ?
                Convert.ToBoolean(saldo) :
                false;

            this.serial = serial;
        }
    }
}
