using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxRemessasIdentificadores", Schema = "untreated")]
    public class LinxRemessasIdentificadores
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_venda { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_remessa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_remessas { get; private set; }

        [Column(TypeName = "int")]
        public string? id_remessas_acertos { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_acerto { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_total_acerto { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_devolucao { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_remessa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_remessa_operacoes { get; private set; }
    }
}
