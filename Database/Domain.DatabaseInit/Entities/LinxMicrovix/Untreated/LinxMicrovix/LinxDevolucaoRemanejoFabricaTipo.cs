using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxDevolucaoRemanejoFabricaTipo", Schema = "untreated")]
    public class LinxDevolucaoRemanejoFabricaTipo
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_devolucao_remanejo_fabrica_tipo { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
