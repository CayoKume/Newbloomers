using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecos
    {
        [NotMapped]
        [SkipProperty]
        public Int32 id { get; set; }

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
            List<ValidationResult> listValidations,
            string? id_prod_tab_preco,
            string? id_tabela,
            string? codigoproduto,
            string? precovenda,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_prod_tab_preco =
                ConvertToInt32Validation.IsValid(id_prod_tab_preco, "id_prod_tab_preco", listValidations) ?
                Convert.ToInt32(id_prod_tab_preco) :
                0;

            this.id_tabela =
                ConvertToInt32Validation.IsValid(id_tabela, "id_tabela", listValidations) ?
                Convert.ToInt32(id_tabela) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.precovenda =
                ConvertToDecimalValidation.IsValid(precovenda, "precovenda", listValidations) ?
                Convert.ToDecimal(precovenda, new CultureInfo("en-US")) :
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
