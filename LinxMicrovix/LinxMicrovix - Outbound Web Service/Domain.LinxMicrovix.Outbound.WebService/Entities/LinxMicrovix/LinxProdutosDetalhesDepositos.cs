using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutosDetalhesDepositos", Schema = "linx_microvix_erp")]
    public class LinxProdutosDetalhesDepositos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? cod_produto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_deposito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? saldo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosDetalhesDepositos() { }

        public LinxProdutosDetalhesDepositos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_produto,
            string? empresa,
            string? cod_deposito,
            string? saldo,
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

            this.cod_deposito =
                ConvertToInt32Validation.IsValid(cod_deposito, "cod_deposito", listValidations) ?
                Convert.ToInt32(cod_deposito) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produtocod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.saldo =
                ConvertToDecimalValidation.IsValid(saldo, "saldo", listValidations) ?
                Convert.ToDecimal(saldo, new CultureInfo("en-US")) :
                0;

            this.cnpj_emp = cnpj_emp;
        }
    }
}
