using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxOrdensServicoPosicaoOsRamoOpticoHistorico", Schema = "untreated")]
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistorico
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_ordens_servico_posicao_os_ramo_optico_historico { get; private set; }

        [Column(TypeName = "int")]
        public string? numero_os { get; private set; }

        [Column(TypeName = "int")]
        public string? usuario { get; private set; }

        [Column(TypeName = "int")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_posicao_os_ramo_optico { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? portal { get; private set; }
    }
}
