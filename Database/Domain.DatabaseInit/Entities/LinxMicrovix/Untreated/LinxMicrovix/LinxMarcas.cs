using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMarcas", Schema = "untreated")]
    public class LinxMarcas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_marca { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_marca { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_ws { get; private set; }
    }
}
