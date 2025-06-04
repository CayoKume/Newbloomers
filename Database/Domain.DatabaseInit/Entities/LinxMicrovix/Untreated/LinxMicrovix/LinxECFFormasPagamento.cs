using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxECFFormasPagamento", Schema = "untreated")]
    public class LinxECFFormasPagamento
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_empresa_ecf_formas_pgto { get; private set; }

        [Column(TypeName = "int")]
        public string? id_ecf { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(53)")]
        public string? indice_forma { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
