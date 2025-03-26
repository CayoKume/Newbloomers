using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaPlanosParcelas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPlanosParcelas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "int")]
        public string? ordem_parcela { get; private set; }

        [Column(TypeName = "int")]
        public string? prazo_parc { get; private set; }

        [Column(TypeName = "int")]
        public string? id_planos_parcelas { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
