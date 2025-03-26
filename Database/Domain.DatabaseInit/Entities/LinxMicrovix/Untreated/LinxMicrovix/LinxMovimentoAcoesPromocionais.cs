using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoAcoesPromocionais", Schema = "untreated")]
    public class LinxMovimentoAcoesPromocionais
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_acoes_promocionais { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_item { get; private set; }

        [Column(TypeName = "int")]
        public string? quantidade { get; private set; }
    }
}
