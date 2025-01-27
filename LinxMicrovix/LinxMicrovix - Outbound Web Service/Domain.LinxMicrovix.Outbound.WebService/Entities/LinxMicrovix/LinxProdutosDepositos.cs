using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutosDepositos", Schema = "linx_microvix_erp")]
    public class LinxProdutosDepositos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_deposito { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nome_deposito")]
        public string? nome_deposito { get; private set; }

        [Column(TypeName = "bit")]
        public bool? disponivel { get; private set; }

        [Column(TypeName = "bit")]
        public bool? disponivel_transferencia { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxProdutosDepositos() { }

        public LinxProdutosDepositos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_deposito,
            string? nome_deposito,
            string? disponivel,
            string? disponivel_transferencia,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_deposito =
                ConvertToInt32Validation.IsValid(cod_deposito, "cod_deposito", listValidations) ?
                Convert.ToInt32(cod_deposito) :
                0;

            this.disponivel =
                ConvertToBooleanValidation.IsValid(disponivel, "disponivel", listValidations) ?
                Convert.ToBoolean(disponivel) :
                false;

            this.disponivel_transferencia =
                ConvertToBooleanValidation.IsValid(disponivel_transferencia, "disponivel_transferencia", listValidations) ?
                Convert.ToBoolean(disponivel_transferencia) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_deposito = nome_deposito;
        }
    }
}
