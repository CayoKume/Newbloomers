using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaCodigoRastreio
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pedido { get; private set; }

        [Column(TypeName = "int")]
        public Int32? documento { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_rastreio { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? sequencia_volume { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaCodigoRastreio() { }

        public B2CConsultaCodigoRastreio(
            string? id_pedido,
            string? documento,
            string? serie,
            string? codigo_rastreio,
            string? sequencia_volume,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_pedido =
                String.IsNullOrEmpty(id_pedido) ? 0
                : Convert.ToInt32(id_pedido);

            this.documento =
                String.IsNullOrEmpty(documento) ? 0
                : Convert.ToInt32(documento);

            this.serie =
                String.IsNullOrEmpty(serie) ? ""
                : serie.Substring(
                    0,
                    serie.Length > 10 ? 10
                    : serie.Length
                );

            this.codigo_rastreio =
                String.IsNullOrEmpty(codigo_rastreio) ? ""
                : codigo_rastreio.Substring(
                    0,
                    codigo_rastreio.Length > 20 ? 20
                    : codigo_rastreio.Length
                );

            this.sequencia_volume =
                String.IsNullOrEmpty(sequencia_volume) ? ""
                : sequencia_volume.Substring(
                    0,
                    sequencia_volume.Length > 20 ? 20
                    : sequencia_volume.Length
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
