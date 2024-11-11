using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaUnidade
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "varchar(50)")]
        public string? unidade { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaUnidade() { }

        public B2CConsultaUnidade(
            string? unidade,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.unidade =
               String.IsNullOrEmpty(unidade) ? ""
               : unidade.Substring(
                   0,
                   unidade.Length > 50 ? 50
                   : unidade.Length
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
