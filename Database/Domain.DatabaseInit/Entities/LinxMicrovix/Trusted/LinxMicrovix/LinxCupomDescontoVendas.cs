using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxCupomDescontoVendas", Schema = "linx_microvix_erp")]
    public class LinxCupomDescontoVendas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_cupom_desconto_vendas { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cupom_desconto { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
