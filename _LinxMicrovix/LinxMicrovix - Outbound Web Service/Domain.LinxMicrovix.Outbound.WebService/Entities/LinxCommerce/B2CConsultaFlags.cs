using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaFlags
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_b2c_flags { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public B2CConsultaFlags() { }

        public B2CConsultaFlags(
            string? portal,
            string? id_b2c_flags,
            string? descricao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_flags =
                String.IsNullOrEmpty(id_b2c_flags) ? 0
                : Convert.ToInt32(id_b2c_flags);

            this.descricao =
                String.IsNullOrEmpty(descricao) ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 300 ? 300
                    : descricao.Length
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
