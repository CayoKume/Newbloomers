
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_prod_tab_preco { get; private set; }
        public Int32? id_tabela { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public decimal? precovenda { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosTabelasPrecos() { }

        public B2CConsultaProdutosTabelasPrecos(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosTabelasPrecos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_prod_tab_preco = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prod_tab_preco);
            this.id_tabela = CustomConvertersExtensions.ConvertToInt32Validation(record.id_tabela);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.precovenda = CustomConvertersExtensions.ConvertToDecimalValidation(record.precovenda);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.recordXml = recordXml;
        }
    }
}
