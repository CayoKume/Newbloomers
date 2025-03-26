using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxLojasParametros", Schema = "untreated")]
    public class LinxLojasParametros
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? percentual_minimo_antecipacao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
