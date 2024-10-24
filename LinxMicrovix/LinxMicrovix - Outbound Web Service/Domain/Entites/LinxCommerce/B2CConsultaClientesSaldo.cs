using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaClientesSaldo
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "money")]
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
                saldo == String.Empty ? 0
                : Convert.ToDecimal(saldo);

            this.cod_cliente_erp =
                cod_cliente_erp == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.empresa =
                empresa == String.Empty ? 0
                : Convert.ToInt32(empresa);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
