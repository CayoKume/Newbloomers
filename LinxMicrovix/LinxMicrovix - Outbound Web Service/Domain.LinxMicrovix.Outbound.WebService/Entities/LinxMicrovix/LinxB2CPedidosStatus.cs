using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CPedidosStatus
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id { get; set; }

        [Column(TypeName = "int")]
        public Int32? id_status { get; set; }

        [Column(TypeName = "int")]
        public Int32? id_pedido { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_hora { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string? anotacao { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }

        public LinxB2CPedidosStatus() { }

        public LinxB2CPedidosStatus(
            string id,
            string id_status,
            string id_pedido,
            string data_hora,
            string anotacao,
            string timestamp,
            string portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id =
                id == String.Empty ? 0
                : Convert.ToInt32(id);

            this.id_status =
                id_status == String.Empty ? 0
                : Convert.ToInt32(id_status);

            this.id_pedido =
                id_pedido == String.Empty ? 0
                : Convert.ToInt32(id_pedido);

            this.data_hora =
                String.IsNullOrEmpty(data_hora) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_hora);

            this.anotacao =
                anotacao == String.Empty ? ""
                : anotacao.Substring(
                    0,
                    anotacao.Length > 80 ? 80
                    : anotacao.Length
                );

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
