
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosAssociados
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int64? codigoproduto_associado { get; private set; }
        public decimal? coeficiente_desconto { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }
        public decimal? qtde_item { get; private set; }
        public Int32? item_obrigatorio { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosAssociados() { }

        public B2CConsultaProdutosAssociados(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosAssociados record,
            string? recordXml)
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.id = CustomConvertersExtensions.ConvertToInt32Validation(record.id);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.codigoproduto_associado = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto_associado);
            this.coeficiente_desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.coeficiente_desconto);
            this.qtde_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_item);
            this.item_obrigatorio = CustomConvertersExtensions.ConvertToInt32Validation(record.item_obrigatorio);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.recordXml = recordXml;
        }
    }
}
