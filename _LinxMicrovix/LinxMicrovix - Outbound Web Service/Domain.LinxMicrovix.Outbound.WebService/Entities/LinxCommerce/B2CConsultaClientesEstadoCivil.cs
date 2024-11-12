using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivil
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_estado_civil { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? estado_civil { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClientesEstadoCivil() { }

        public B2CConsultaClientesEstadoCivil(
            string? id_estado_civil,
            string? estado_civil,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_estado_civil =
                String.IsNullOrEmpty(id_estado_civil) ? 0
                : Convert.ToInt32(id_estado_civil);

            this.estado_civil =
                String.IsNullOrEmpty(estado_civil) ? ""
                : estado_civil.Substring(
                    0,
                    estado_civil.Length > 20 ? 20
                    : estado_civil.Length
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
