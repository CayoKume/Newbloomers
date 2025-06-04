using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMetasVendedores", Schema = "untreated")]
    public class LinxMetasVendedores
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_meta { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao_meta { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_inicial_meta { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_final_meta { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_meta_loja { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_meta_vendedor { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
