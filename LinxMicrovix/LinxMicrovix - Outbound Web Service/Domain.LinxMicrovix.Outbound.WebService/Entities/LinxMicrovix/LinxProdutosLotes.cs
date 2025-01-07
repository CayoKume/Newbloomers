using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosLotes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "lote")]
        public string? lote { get; private set; }

        [Column(TypeName = "int")]
        public Int32? deposito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? saldo_disponivel { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxProdutosLotes() { }

        public LinxProdutosLotes(
            List<ValidationResult> listValidations,
            string? portal,
            string? codigoproduto,
            string? empresa,
            string? lote,
            string? deposito,
            string? saldo_disponivel,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.deposito =
                ConvertToInt32Validation.IsValid(deposito, "deposito", listValidations) ?
                Convert.ToInt32(deposito) :
                0;

            this.saldo_disponivel =
                ConvertToDecimalValidation.IsValid(saldo_disponivel, "saldo_disponivel", listValidations) ?
                Convert.ToDecimal(saldo_disponivel) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.lote = lote;
        }
    }
}
