using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxFaturasOrigem", Schema = "untreated")]
    public class LinxFaturasOrigem
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigo_fatura { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigo_fatura_origem { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
