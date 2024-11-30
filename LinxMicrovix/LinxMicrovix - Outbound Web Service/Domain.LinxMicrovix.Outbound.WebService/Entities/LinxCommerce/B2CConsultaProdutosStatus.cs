using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "referencia")]
        public string? referencia { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? b2c { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosStatus() { }

        public B2CConsultaProdutosStatus(
            List<ValidationResult> listValidations,
            string? codigoproduto,
            string? referencia,
            string? ativo,
            string? b2c,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigoproduto =
               String.IsNullOrEmpty(codigoproduto) ? 0
               : Convert.ToInt64(codigoproduto);

            this.referencia = referencia;

            this.ativo =
               String.IsNullOrEmpty(ativo) ? 0
               : Convert.ToInt32(ativo);

            this.b2c =
               String.IsNullOrEmpty(b2c) ? 0
               : Convert.ToInt32(b2c);

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
