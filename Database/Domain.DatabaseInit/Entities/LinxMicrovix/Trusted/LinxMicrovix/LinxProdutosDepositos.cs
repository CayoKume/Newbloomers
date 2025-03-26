using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxProdutosDepositos", Schema = "linx_microvix_erp")]
    public class LinxProdutosDepositos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_deposito { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_deposito { get; private set; }

        [Column(TypeName = "bit")]
        public string? disponivel { get; private set; }

        [Column(TypeName = "bit")]
        public string? disponivel_transferencia { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
