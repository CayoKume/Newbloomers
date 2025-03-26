using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxCfopFiscal", Schema = "untreated")]
    public class LinxCfopFiscal
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string id_cfop_fiscal { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? cfop_fiscal { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public string excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public string timestamp { get; private set; }
    }
}
