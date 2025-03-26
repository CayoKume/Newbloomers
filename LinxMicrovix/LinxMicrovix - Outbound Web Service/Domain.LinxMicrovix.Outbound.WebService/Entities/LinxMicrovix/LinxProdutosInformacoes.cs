using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutosInformacoes", Schema = "linx_microvix_erp")]
    public class LinxProdutosInformacoes
    {
        public DateTime? lastupdateon { get; private set; }

        public Int64? codigoproduto { get; set; }

        public string? informacoes_produto { get; set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosInformacoes() { }

        public LinxProdutosInformacoes(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? informacoes_produto
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.informacoes_produto = informacoes_produto;
        }
    }
}
