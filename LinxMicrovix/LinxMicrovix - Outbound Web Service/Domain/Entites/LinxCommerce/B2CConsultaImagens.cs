using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaImagens
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_imagem { get; private set; }

        [Column(TypeName = "image")]
        public string? imagem { get; private set; }

        [Column(TypeName = "char(32)")]
        public string? md5 { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? url_imagem_blob { get; private set; }

        public B2CConsultaImagens() { }

        public B2CConsultaImagens(
            string? id_imagem,
            string? imagem,
            string? md5,
            string? timestamp,
            string? portal,
            string? url_imagem_blob
        )
        {
            lastupdateon = DateTime.Now;

            this.id_imagem =
                String.IsNullOrEmpty(id_imagem) ? 0
                : Convert.ToInt32(id_imagem);

            this.imagem =
                String.IsNullOrEmpty(imagem) ? ""
                : imagem;

            this.md5 =
                String.IsNullOrEmpty(md5) ? ""
                : md5.Substring(
                    0,
                    md5.Length > 32 ? 32
                    : md5.Length
                );

            this.url_imagem_blob =
                String.IsNullOrEmpty(url_imagem_blob) ? ""
                : url_imagem_blob.Substring(
                    0,
                    url_imagem_blob.Length > 200 ? 200
                    : url_imagem_blob.Length
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
