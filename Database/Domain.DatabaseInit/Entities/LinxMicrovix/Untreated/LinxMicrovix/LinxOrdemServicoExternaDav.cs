using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxOrdemServicoExternaDav", Schema = "untreated")]
    public class LinxOrdemServicoExternaDav
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_vendas_pos_tmp_ordem_servico_externa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_ordem_servico_externa { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
