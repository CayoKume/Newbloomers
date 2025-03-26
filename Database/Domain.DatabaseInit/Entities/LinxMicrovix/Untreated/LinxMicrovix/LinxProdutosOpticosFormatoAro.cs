using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxProdutosOpticosFormatoAro", Schema = "untreated")]
    public class LinxProdutosOpticosFormatoAro
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_formato_aro { get; private set; }

        [Column(TypeName = "varchar(16)")]
        public string? codigo { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
