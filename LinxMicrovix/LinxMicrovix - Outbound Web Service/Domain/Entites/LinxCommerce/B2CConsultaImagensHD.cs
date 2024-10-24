using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaImagensHD
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador_imagem { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "varbinary(MAX)")]
        public string? imagem { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? url_imagem_blob { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaImagensHD() { }

        public B2CConsultaImagensHD(
            string? identificador_imagem,
            string? codigoproduto,
            string? imagem,
            string? timestamp,
            string? url_imagem_blob,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.identificador_imagem =
                identificador_imagem == String.Empty ? new Guid()
                : Guid.Parse(identificador_imagem);

            this.codigoproduto =
                codigoproduto == String.Empty ? 0
                : Convert.ToInt32(codigoproduto);

            this.imagem =
                imagem == String.Empty ? ""
                : imagem;

            this.url_imagem_blob =
                url_imagem_blob == String.Empty ? ""
                : url_imagem_blob.Substring(
                    0,
                    url_imagem_blob.Length > 200 ? 200
                    : url_imagem_blob.Length
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
