using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxTamanhos", Schema = "untreated")]
    public class LinxTamanhos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? id_tamanho { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? desc_tamanho { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_integracao_ws { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }
    }
}
