using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
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
            List<ValidationResult> listValidations,
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

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
