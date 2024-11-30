using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

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
                String.IsNullOrEmpty(altura) ? 0
                : Convert.ToDecimal(altura);

            this.comprimento =
                String.IsNullOrEmpty(comprimento) ? 0
                : Convert.ToDecimal(comprimento);

            this.largura =
                String.IsNullOrEmpty(largura) ? 0
                : Convert.ToDecimal(largura);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

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
