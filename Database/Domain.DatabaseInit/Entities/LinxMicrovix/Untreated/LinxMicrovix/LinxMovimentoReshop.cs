using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoReshop", Schema = "untreated")]
    public class LinxMovimentoReshop
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? id_movimento_campanha_reshop { get; private set; }

        [Column(TypeName = "int")]
        public string? id_campanha { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(200)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public string? aplicar_desconto_venda { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_desconto_subtotal { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_desconto_completo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
