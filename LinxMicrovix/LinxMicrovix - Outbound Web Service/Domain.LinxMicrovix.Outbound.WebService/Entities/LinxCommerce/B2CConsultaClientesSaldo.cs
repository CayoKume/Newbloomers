using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientesSaldo
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? saldo { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClientesSaldo() { }

        public B2CConsultaClientesSaldo(
            string? saldo,
            string? cod_cliente_erp,
            string? empresa,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.saldo =
                String.IsNullOrEmpty(saldo) ? 0
                : Convert.ToDecimal(saldo);

            this.cod_cliente_erp =
                String.IsNullOrEmpty(cod_cliente_erp) ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
