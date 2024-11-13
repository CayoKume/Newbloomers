using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaFormasPagamento
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaFormasPagamento() { }

        public B2CConsultaFormasPagamento(
            string? cod_forma_pgto,
            string? forma_pgto,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_forma_pgto =
                String.IsNullOrEmpty(cod_forma_pgto) ? 0
                : Convert.ToInt32(cod_forma_pgto);

            this.forma_pgto =
                String.IsNullOrEmpty(forma_pgto) ? ""
                : forma_pgto.Substring(
                    0,
                    forma_pgto.Length > 50 ? 50
                    : forma_pgto.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
