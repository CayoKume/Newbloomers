using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaProdutosFlags
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_b2c_flags_produtos { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_b2c_flags { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao_b2c_flags { get; private set; }

        public B2CConsultaProdutosFlags() { }

        public B2CConsultaProdutosFlags(
            string? portal,
            string? id_b2c_flags_produtos,
            string? id_b2c_flags,
            string? codigoproduto,
            string? timestamp,
            string? descricao_b2c_flags
        )
        {
            lastupdateon = DateTime.Now;

            this.id_b2c_flags_produtos =
                String.IsNullOrEmpty(id_b2c_flags_produtos) ? 0
                : Convert.ToInt32(id_b2c_flags_produtos);

            this.id_b2c_flags =
                String.IsNullOrEmpty(id_b2c_flags) ? 0
                : Convert.ToInt32(id_b2c_flags);

            this.codigoproduto =
                String.IsNullOrEmpty(codigoproduto) ? 0
                : Convert.ToInt64(codigoproduto);

            this.descricao_b2c_flags =
                String.IsNullOrEmpty(descricao_b2c_flags) ? ""
                : descricao_b2c_flags.Substring(
                    0,
                    descricao_b2c_flags.Length > 300 ? 300
                    : descricao_b2c_flags.Length
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
