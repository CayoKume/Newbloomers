using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxMovimentoReshopItens
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_movimento_campanha_reshop_item { get; private set; }

        public Int32? id_campanha { get; private set; }

        public Guid? identificador { get; private set; }

        public decimal? valor_unitario { get; private set; }

        public decimal? valor_desconto_item { get; private set; }

        public decimal quantidade { get; private set; }

        public decimal? valor_original { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? ordem { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoReshopItens() { }

        public LinxMovimentoReshopItens(
            List<ValidationResult> listValidations,
            string? id_movimento_campanha_reshop_item,
            string? id_campanha,
            string? identificador,
            string? valor_unitario,
            string? valor_desconto_item,
            string? quantidade,
            string? valor_original,
            string? timestamp,
            string? ordem
        )
        {
            lastupdateon = DateTime.Now;

            this.id_movimento_campanha_reshop_item =
                ConvertToInt32Validation.IsValid(id_movimento_campanha_reshop_item, "id_movimento_campanha_reshop_item", listValidations) ?
                Convert.ToInt32(id_movimento_campanha_reshop_item) :
                0;

            this.id_campanha =
                ConvertToInt32Validation.IsValid(id_campanha, "id_campanha", listValidations) ?
                Convert.ToInt32(id_campanha) :
                0;

            this.ordem =
                ConvertToInt32Validation.IsValid(ordem, "ordem", listValidations) ?
                Convert.ToInt32(ordem) :
                0;

            this.valor_unitario =
               ConvertToDecimalValidation.IsValid(valor_unitario, "valor_unitario", listValidations) ?
               Convert.ToDecimal(valor_unitario, new CultureInfo("en-US")) :
               0;

            this.valor_desconto_item =
               ConvertToDecimalValidation.IsValid(valor_desconto_item, "valor_desconto_item", listValidations) ?
               Convert.ToDecimal(valor_desconto_item, new CultureInfo("en-US")) :
               0;

            this.quantidade =
               ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
               Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
               0;

            this.valor_original =
               ConvertToDecimalValidation.IsValid(valor_original, "valor_original", listValidations) ?
               Convert.ToDecimal(valor_original, new CultureInfo("en-US")) :
               0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
