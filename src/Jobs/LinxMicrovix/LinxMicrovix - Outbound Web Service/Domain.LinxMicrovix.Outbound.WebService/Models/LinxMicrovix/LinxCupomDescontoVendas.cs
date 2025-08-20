using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCupomDescontoVendas
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? id_cupom_desconto_vendas { get; private set; }

        public Int32? id_cupom_desconto { get; private set; }

        public Guid? identificador { get; private set; }

        public decimal? valor { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? id_vendas_pos { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCupomDescontoVendas() { }

        public LinxCupomDescontoVendas(
            List<ValidationResult> listValidations,
            string? portal,
            string? empresa,
            string? id_cupom_desconto_vendas,
            string? id_cupom_desconto,
            string? identificador,
            string? valor,
            string? timestamp,
            string? id_vendas_pos
        )
        {
            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_cupom_desconto_vendas =
                ConvertToInt32Validation.IsValid(id_cupom_desconto_vendas, "id_cupom_desconto_vendas", listValidations) ?
                Convert.ToInt32(id_cupom_desconto_vendas) :
                0;

            this.id_cupom_desconto =
                ConvertToInt32Validation.IsValid(id_cupom_desconto, "id_cupom_desconto", listValidations) ?
                Convert.ToInt32(id_cupom_desconto) :
                0;

            this.id_vendas_pos =
                ConvertToInt32Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt32(id_vendas_pos) :
                0;

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor, new CultureInfo("en-US")) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
