using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxPlanosBandeiras", Schema = "untreated")]
    public class LinxPlanosBandeiras
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? bandeira { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? tipo_bandeira { get; private set; }

        [Column(TypeName = "int")]
        public string? adquirente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_adquirente { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? codigo_bandeira_sitef { get; private set; }
    }
}
