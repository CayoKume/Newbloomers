using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaPedidosTipos", Schema = "linx_microvix_commerce")]
    public class B2CConsultaPedidosTipos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_tipo_b2c { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? pos_timestamp_old { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
