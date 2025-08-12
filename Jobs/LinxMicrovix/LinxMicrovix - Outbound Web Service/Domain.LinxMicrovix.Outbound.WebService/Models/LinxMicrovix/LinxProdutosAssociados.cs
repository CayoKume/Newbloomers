
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosAssociados
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto_associado { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? codigoproduto_origem { get; private set; }
        public decimal? coeficiente_desconto { get; private set; }
        public Int64? timestamp { get; private set; }
        public decimal? qtde_item { get; private set; }
        public bool? item_obrigatorio { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosAssociados() { }

        public LinxProdutosAssociados(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosAssociados record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.coeficiente_desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.coeficiente_desconto);
            this.qtde_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_item);
            this.item_obrigatorio = CustomConvertersExtensions.ConvertToBooleanValidation(record.item_obrigatorio);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.codigoproduto_associado = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto_associado);
            this.codigoproduto_origem = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto_origem);
            
        }
    }
}
