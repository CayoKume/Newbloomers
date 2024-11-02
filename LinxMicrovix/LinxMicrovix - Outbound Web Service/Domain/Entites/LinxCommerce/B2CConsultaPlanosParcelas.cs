using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaPlanosParcelas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? ordem_parcela { get; private set; }

        [Column(TypeName = "int")]
        public Int32? prazo_parc { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_planos_parcelas { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaPlanosParcelas() { }

        public B2CConsultaPlanosParcelas(
            string? plano,
            string? ordem_parcela,
            string? prazo_parc,
            string? id_planos_parcelas,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.plano =
                String.IsNullOrEmpty(plano) ? 0
                : Convert.ToInt32(plano);

            this.ordem_parcela =
                String.IsNullOrEmpty(ordem_parcela) ? 0
                : Convert.ToInt32(ordem_parcela);

            this.prazo_parc =
                String.IsNullOrEmpty(prazo_parc) ? 0
                : Convert.ToInt32(prazo_parc);

            this.id_planos_parcelas =
                String.IsNullOrEmpty(id_planos_parcelas) ? 0
                : Convert.ToInt32(id_planos_parcelas);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
