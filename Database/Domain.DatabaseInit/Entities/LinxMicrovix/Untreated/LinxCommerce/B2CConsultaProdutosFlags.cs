using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosFlags", Schema = "untreated")]
    public class B2CConsultaProdutosFlags
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_b2c_flags_produtos { get; private set; }

        [Column(TypeName = "int")]
        public string? id_b2c_flags { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(300)")]
        public string? descricao_b2c_flags { get; private set; }
    }
}
