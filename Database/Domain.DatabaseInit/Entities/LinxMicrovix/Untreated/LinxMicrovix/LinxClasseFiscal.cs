using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxClasseFiscal", Schema = "untreated")]
    public class LinxClasseFiscal
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string id_classe_fiscal { get; private set; }

        [Column(TypeName = "varchar(150)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public string excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public string timestamp { get; private set; }
    }
}
