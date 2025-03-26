using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoVendaConjugada", Schema = "untreated")]
    public class LinxMovimentoVendaConjugada
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_produto { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_servico { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
