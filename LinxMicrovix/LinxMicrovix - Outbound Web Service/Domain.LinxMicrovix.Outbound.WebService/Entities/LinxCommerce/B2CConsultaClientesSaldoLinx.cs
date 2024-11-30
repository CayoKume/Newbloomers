using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinx
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_b2c { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClientesSaldoLinx() { }

        public B2CConsultaClientesSaldoLinx(
            List<ValidationResult> listValidations,
            string? cod_cliente_erp,
            string? cod_cliente_b2c,
            string? empresa,
            string? valor,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_cliente_b2c =
                String.IsNullOrEmpty(cod_cliente_b2c) ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.cod_cliente_erp =
                String.IsNullOrEmpty(cod_cliente_erp) ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.valor =
                String.IsNullOrEmpty(valor) ? 0
                : Convert.ToDecimal(valor);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

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
