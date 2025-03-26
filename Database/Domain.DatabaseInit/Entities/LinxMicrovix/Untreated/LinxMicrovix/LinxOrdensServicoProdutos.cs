using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxOrdensServicoProdutos", Schema = "untreated")]
    public class LinxOrdensServicoProdutos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_ordservprod { get; private set; }

        [Column(TypeName = "bigint")]
        public string? cod_produto_serv { get; private set; }

        [Column(TypeName = "int")]
        public string? numero_os { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
