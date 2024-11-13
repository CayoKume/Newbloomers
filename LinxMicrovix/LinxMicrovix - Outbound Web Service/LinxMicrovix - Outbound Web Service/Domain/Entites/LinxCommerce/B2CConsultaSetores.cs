using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaSetores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_setor { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_setor { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaSetores() { }

        public B2CConsultaSetores(
            string? codigo_setor,
            string? nome_setor,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.nome_setor =
                String.IsNullOrEmpty(nome_setor) ? ""
                : nome_setor.Substring(
                    0,
                    nome_setor.Length > 100 ? 100
                    : nome_setor.Length
                );

            this.codigo_setor =
                String.IsNullOrEmpty(codigo_setor) ? 0
                : Convert.ToInt32(codigo_setor);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
