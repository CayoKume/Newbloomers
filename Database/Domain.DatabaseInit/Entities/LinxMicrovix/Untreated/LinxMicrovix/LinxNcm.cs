using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxNcm", Schema = "untreated")]
    public class LinxNcm
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_genero { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_ncm { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }
    }
}
