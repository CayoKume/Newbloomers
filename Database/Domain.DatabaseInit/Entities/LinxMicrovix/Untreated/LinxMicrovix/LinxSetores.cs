using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxSetores", Schema = "untreated")]
    public class LinxSetores
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_setor { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_setor { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }
    }
}
