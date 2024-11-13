using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaGrade2
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? codigo_grade2 { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? nome_grade2 { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaGrade2() { }

        public B2CConsultaGrade2(
            string? codigo_grade2,
            string? nome_grade2,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_grade2 =
                String.IsNullOrEmpty(codigo_grade2) ? 0
                : Convert.ToInt32(codigo_grade2);

            this.nome_grade2 =
                String.IsNullOrEmpty(nome_grade2) ? ""
                : nome_grade2.Substring(
                    0,
                    nome_grade2.Length > 100 ? 100
                    : nome_grade2.Length
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
