using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxMovimentoReshopItens", Schema = "linx_microvix_erp")]
    public class LinxMovimentoReshopItens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_movimento_campanha_reshop_item { get; private set; }

        [Column(TypeName = "int")]
        public string? id_campanha { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_unitario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_desconto_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_original { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? ordem { get; private set; }
    }
}
