using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaProdutosDetalhesDepositos", Schema = "untreated")]
    public class B2CConsultaProdutosDetalhesDepositos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_deposito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? saldo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? deposito { get; private set; }

        [Column(TypeName = "smallint")]
        public string? tempo_preparacao_estoque { get; private set; }
    }
}
