using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaNFeSituacao
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "tinyint")]
        public Int32? id_nfe_situacao { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaNFeSituacao() { }

        public B2CConsultaNFeSituacao(
            string? id_nfe_situacao,
            string? descricao,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_nfe_situacao =
                String.IsNullOrEmpty(id_nfe_situacao) ? 0
                : Convert.ToInt32(id_nfe_situacao);

            this.descricao =
                String.IsNullOrEmpty(descricao) ? ""
                : descricao.Substring(
                    0,
                    descricao.Length > 30 ? 30
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
