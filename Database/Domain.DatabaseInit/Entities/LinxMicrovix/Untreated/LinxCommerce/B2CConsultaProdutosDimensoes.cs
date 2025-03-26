using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosDimensoes", Schema = "untreated")]
    public class B2CConsultaProdutosDimensoes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? altura { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? comprimento { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? largura { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
