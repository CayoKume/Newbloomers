using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxPlanos", Schema = "linx_microvix_erp")]
    public class LinxPlanos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        public string? desc_plano { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_parcelas { get; private set; }

        [Column(TypeName = "int")]
        public string? prazo_entre_parcelas { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? indice_plano { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public string? conta_central { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_transacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? taxa_financeira { get; private set; }

        [Column(TypeName = "int")]
        public string? dt_upd { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? desativado { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? usa_tef { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }
    }
}
