using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxComissoesVendedores", Schema = "linx_microvix_erp")]
    public class LinxComissoesVendedores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? vendedor { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_origem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_base { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_comissao { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "disponivel")]
        public string? disponivel { get; private set; }


        public Int64? timestamp { get; private set; }

        public LinxComissoesVendedores() { }

        public LinxComissoesVendedores(
            List<ValidationResult> listValidations,
            string? vendedor,
            string? empresa,
            string? data_origem,
            string? valor_base,
            string? valor_comissao,
            string? cancelado,
            string? disponivel,
            string? timestamp
        )
        {
            this.vendedor =
                ConvertToInt32Validation.IsValid(vendedor, "vendedor", listValidations) ?
                Convert.ToInt32(vendedor) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.valor_base =
                ConvertToDecimalValidation.IsValid(valor_base, "valor_base", listValidations) ?
                Convert.ToDecimal(valor_base) :
                0;

            this.valor_comissao =
                ConvertToDecimalValidation.IsValid(valor_comissao, "valor_comissao", listValidations) ?
                Convert.ToDecimal(valor_comissao) :
                0;

            this.data_origem =
                ConvertToDateTimeValidation.IsValid(data_origem, "data_origem", listValidations) ?
                Convert.ToDateTime(data_origem) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cancelado = cancelado;
            this.disponivel = disponivel;
        }
    }
}
