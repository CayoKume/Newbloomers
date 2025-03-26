using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxProdutosTabelasPrecos", Schema = "untreated")]
    public class LinxProdutosTabelasPrecos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_tabela { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? precovenda { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
