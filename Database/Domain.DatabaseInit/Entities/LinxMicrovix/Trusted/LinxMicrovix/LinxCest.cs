using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxCest", Schema = "linx_microvix_erp")]
    public class LinxCest
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_cest { get; private set; }

        [Column(TypeName = "varchar(700)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? cest { get; private set; }

        [Column(TypeName = "int")]
        public string? id_segmento_mercadoria_bem { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
