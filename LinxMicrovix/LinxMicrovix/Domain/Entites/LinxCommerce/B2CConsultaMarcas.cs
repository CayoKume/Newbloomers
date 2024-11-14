using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaMarcas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_marca { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_marca { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? linhas { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaMarcas() { }

        public B2CConsultaMarcas(
            string? codigo_marca,
            string? nome_marca,
            string? timestamp,
            string? linhas,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_marca =
                String.IsNullOrEmpty(codigo_marca) ? 0
                : Convert.ToInt32(codigo_marca);

            this.nome_marca =
                String.IsNullOrEmpty(nome_marca) ? ""
                : nome_marca.Substring(
                    0,
                    nome_marca.Length > 100 ? 100
                    : nome_marca.Length
                );

            this.linhas =
                String.IsNullOrEmpty(linhas) ? ""
                : linhas.Substring(
                    0,
                    linhas.Length > 250 ? 250
                    : linhas.Length
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
