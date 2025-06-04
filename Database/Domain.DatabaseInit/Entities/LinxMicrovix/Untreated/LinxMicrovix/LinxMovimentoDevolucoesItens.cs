using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoDevolucoesItens", Schema = "untreated")]
    public class LinxMovimentoDevolucoesItens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_movimento_devolucoes_itens { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_venda { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_devolucao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_origem { get; private set; }

        [Column(TypeName = "int")]
        public string? transacao_devolucao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? qtde_devolvida { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
