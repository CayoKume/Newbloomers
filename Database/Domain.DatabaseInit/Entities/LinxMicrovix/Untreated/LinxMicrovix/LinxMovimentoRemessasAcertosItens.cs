using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoRemessasAcertosItens", Schema = "untreated")]
    public class LinxMovimentoRemessasAcertosItens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_remessas_acertos { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_total { get; private set; }

        [Column(TypeName = "int")]
        public string? id_remessa_operacoes { get; private set; }

        [Column(TypeName = "int")]
        public string? id_remessas_itens { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
