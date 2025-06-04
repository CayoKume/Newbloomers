using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxCstCofinsFiscal", Schema = "untreated")]
    public class LinxCstCofinsFiscal
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_csosn_fiscal { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? csosn_fiscal { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_csosn_fiscal_substitutiva { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
