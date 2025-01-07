using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosDimensoes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? altura { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? comprimento { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? largura { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosDimensoes() { }

        public B2CConsultaProdutosDimensoes(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? altura,
            string? comprimento,
            string? timestamp,
            string? largura,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.altura =
                ConvertToDecimalValidation.IsValid(altura, "altura", listValidations) ?
                Convert.ToDecimal(altura) :
                0;

            this.comprimento =
                ConvertToDecimalValidation.IsValid(comprimento, "comprimento", listValidations) ?
                Convert.ToDecimal(comprimento) :
                0;

            this.largura =
                ConvertToDecimalValidation.IsValid(largura, "largura", listValidations) ?
                Convert.ToDecimal(largura) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

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
