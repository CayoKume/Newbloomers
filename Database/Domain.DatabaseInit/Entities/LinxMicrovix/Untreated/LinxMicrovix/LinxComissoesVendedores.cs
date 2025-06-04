using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxComissoesVendedores", Schema = "untreated")]
    public class LinxComissoesVendedores
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? vendedor { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_origem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_base { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_comissao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? disponivel { get; private set; }

        public string? timestamp { get; private set; }
    }
}
