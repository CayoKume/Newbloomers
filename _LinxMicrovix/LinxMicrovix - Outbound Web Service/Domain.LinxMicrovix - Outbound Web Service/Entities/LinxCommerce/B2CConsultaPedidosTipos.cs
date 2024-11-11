using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaPedidosTipos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tipo_b2c { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? pos_timestamp_old { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPedidosTipos() { }

        public B2CConsultaPedidosTipos(
            string? id_tipo_b2c,
            string? descricao,
            string? pos_timestamp_old,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_tipo_b2c =
                String.IsNullOrEmpty(id_tipo_b2c) ? 0
                : Convert.ToInt32(id_tipo_b2c);

            this.descricao =
                String.IsNullOrEmpty(descricao) ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 200 ? 200
                    : descricao.Length
                );

            this.pos_timestamp_old =
                String.IsNullOrEmpty(pos_timestamp_old) ? 0
                : Convert.ToInt64(pos_timestamp_old);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
