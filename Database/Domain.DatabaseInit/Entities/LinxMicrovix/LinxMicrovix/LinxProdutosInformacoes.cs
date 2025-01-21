using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxProdutosInformacoes", Schema = "untreated")]
    public class LinxProdutosInformacoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? informacoes_produto { get; set; }

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
