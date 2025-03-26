using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosStatus", Schema = "untreated")]
    public class B2CConsultaProdutosStatus
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? referencia { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public string? b2c { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
