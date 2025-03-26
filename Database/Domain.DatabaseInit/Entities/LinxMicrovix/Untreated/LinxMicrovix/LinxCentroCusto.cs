using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxCentroCusto", Schema = "untreated")]
    public class LinxCentroCusto
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? CNPJ { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_centrocusto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_centrocusto { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
