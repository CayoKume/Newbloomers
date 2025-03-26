using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxPosicaoOsRamoOptico", Schema = "untreated")]
    public class LinxPosicaoOsRamoOptico
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_posicao_os_ramo_optico { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_status_padrao { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
