using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosTags
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_b2c_tags_produtos { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_b2c_tags { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao_b2c_tags { get; private set; }

        public B2CConsultaProdutosTags() { }

        public B2CConsultaProdutosTags(
            string? portal,
            string? id_b2c_tags_produtos,
            string? id_b2c_tags,
            string? codigoproduto,
            string? timestamp,
            string? descricao_b2c_tags
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_tags_produtos =
                String.IsNullOrEmpty(id_b2c_tags_produtos) ? 0
                : Convert.ToInt32(id_b2c_tags_produtos);

            this.id_b2c_tags =
                String.IsNullOrEmpty(id_b2c_tags) ? 0
                : Convert.ToInt32(id_b2c_tags);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.descricao_b2c_tags =
                String.IsNullOrEmpty(descricao_b2c_tags) ? ""
                : descricao_b2c_tags.Substring(
                    0,
                    descricao_b2c_tags.Length > 300 ? 300
                    : descricao_b2c_tags.Length
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
