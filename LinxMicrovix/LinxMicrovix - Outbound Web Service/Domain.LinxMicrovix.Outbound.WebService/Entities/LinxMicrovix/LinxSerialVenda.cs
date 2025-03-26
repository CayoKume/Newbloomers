using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxSerialVenda", Schema = "linx_microvix_erp")]
    public class LinxSerialVenda
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? id_serial_venda { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? transacao { get; private set; }

        public Int64? codigoproduto { get; private set; }

        [LengthValidation(length: 50, propertyName: "serial")]
        public string? serial { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxSerialVenda() { }

        public LinxSerialVenda(
            List<ValidationResult> listValidations,
            string? id_serial_venda,
            string? portal,
            string? transacao,
            string? codigoproduto,
            string? serial,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_serial_venda =
                ConvertToInt32Validation.IsValid(id_serial_venda, "id_serial_venda", listValidations) ?
                Convert.ToInt32(id_serial_venda) :
                0;

            this.transacao =
                ConvertToInt32Validation.IsValid(transacao, "transacao", listValidations) ?
                Convert.ToInt32(transacao) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.serial = serial;
        }
    }
}
