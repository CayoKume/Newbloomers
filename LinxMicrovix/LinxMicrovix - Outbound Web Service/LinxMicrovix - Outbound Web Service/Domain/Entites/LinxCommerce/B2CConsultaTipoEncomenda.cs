using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaTipoEncomenda
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tipo_encomenda { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nm_tipo_encomenda { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaTipoEncomenda() { }

        public B2CConsultaTipoEncomenda(
            string? id_tipo_encomenda,
            string? nm_tipo_encomenda,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.nm_tipo_encomenda =
                String.IsNullOrEmpty(nm_tipo_encomenda) ? ""
                : nm_tipo_encomenda.Substring(
                    0,
                    nm_tipo_encomenda.Length > 100 ? 100
                    : nm_tipo_encomenda.Length
                );

            this.id_tipo_encomenda =
                String.IsNullOrEmpty(id_tipo_encomenda) ? 0
                : Convert.ToInt32(id_tipo_encomenda);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
