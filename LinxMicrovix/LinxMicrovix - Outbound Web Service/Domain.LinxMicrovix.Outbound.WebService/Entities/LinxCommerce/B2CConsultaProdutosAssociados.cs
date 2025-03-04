using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaProdutosAssociados", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosAssociados
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto_associado { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? coeficiente_desconto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_item { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? item_obrigatorio { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosAssociados() { }

        public B2CConsultaProdutosAssociados(
            List<ValidationResult> listValidations,
            string? id,
            string? codigoproduto,
            string? codigoproduto_associado,
            string? coeficiente_desconto,
            string? timestamp,
            string? portal,
            string? qtde_item,
            string? item_obrigatorio,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id =
                ConvertToInt32Validation.IsValid(id, "id", listValidations) ?
                Convert.ToInt32(id) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.codigoproduto_associado =
                ConvertToInt64Validation.IsValid(codigoproduto_associado, "codigoproduto_associado", listValidations) ?
                Convert.ToInt64(codigoproduto_associado) :
                0;

            this.coeficiente_desconto =
                ConvertToDecimalValidation.IsValid(coeficiente_desconto, "coeficiente_desconto", listValidations) ?
                Convert.ToDecimal(coeficiente_desconto, new CultureInfo("en-US")) :
                0;

            this.qtde_item =
                ConvertToDecimalValidation.IsValid(qtde_item, "qtde_item", listValidations) ?
                Convert.ToDecimal(qtde_item, new CultureInfo("en-US")) :
                0;

            this.item_obrigatorio =
                ConvertToInt32Validation.IsValid(item_obrigatorio, "item_obrigatorio", listValidations) ?
                Convert.ToInt32(item_obrigatorio) :
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
