using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxProdutosAssociados", Schema = "untreated")]
    public class LinxProdutosAssociados
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto_associado { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto_origem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? coeficiente_desconto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_item { get; private set; }

        [Column(TypeName = "bit")]
        public bool? item_obrigatorio { get; private set; }

        public LinxProdutosAssociados() { }

        public LinxProdutosAssociados(
            List<ValidationResult> listValidations,
            string? codigoproduto_associado,
            string? portal,
            string? codigoproduto_origem,
            string? coeficiente_desconto,
            string? timestamp,
            string? qtde_item,
            string? item_obrigatorio
        )
        {
            lastupdateon = DateTime.Now;

            this.coeficiente_desconto =
                ConvertToDecimalValidation.IsValid(coeficiente_desconto, "coeficiente_desconto", listValidations) ?
                Convert.ToDecimal(coeficiente_desconto) :
                0;

            this.qtde_item =
                ConvertToDecimalValidation.IsValid(qtde_item, "qtde_item", listValidations) ?
                Convert.ToDecimal(qtde_item) :
                0;

            this.item_obrigatorio =
                ConvertToBooleanValidation.IsValid(item_obrigatorio, "item_obrigatorio", listValidations) ?
                Convert.ToBoolean(item_obrigatorio) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigoproduto_associado =
                ConvertToInt64Validation.IsValid(codigoproduto_associado, "codigoproduto_associado", listValidations) ?
                Convert.ToInt64(codigoproduto_associado) :
                0;

            this.codigoproduto_origem =
                ConvertToInt64Validation.IsValid(codigoproduto_origem, "codigoproduto_origem", listValidations) ?
                Convert.ToInt64(codigoproduto_origem) :
                0;
        }
    }
}
